using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    public bool isOK;

    public RectTransform objectiveBg;
    public TMP_Text objectiveT;
    public RectTransform chapterBG;
    public TMP_Text chapterT;

    public int turnCount;
    public TMP_Text turnT;

    public GameObject PopupP;

    public int watchCharacter;
    public List<GameObject> characterList;

    public bool isEvent;
    public GameObject eventBg;
    public int eventCount;
    public TMP_Text eventT;

    private void OnEnable()
    {
        isOK = true;
        ++turnCount;
        watchCharacter = 0;
        PopupP.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOK)
        {
            // 목표
            int howob;
            if(objectiveT.text.Length >= 10)
            {
                howob = 5;
            }
            else if (objectiveT.text.Length <= 8 && objectiveT.text.Length > 6)
            {
                howob = 4;
            }
            else if (objectiveT.text.Length <= 5 && objectiveT.text.Length > 0)
            {
                howob = 2;
            }
            else
            {
                howob = 1;
            }
            float obj = objectiveT.text.Length * howob;
            objectiveBg.anchoredPosition = new Vector2(-obj, objectiveBg.anchoredPosition.y);

            // 챕터
            int howcha;
            if (chapterT.text.Length >= 10)
            {
                howcha = 5;
            }
            else if (chapterT.text.Length <= 8 && chapterT.text.Length > 6)
            {
                howcha = 4;
            }
            else if (chapterT.text.Length <= 5 && chapterT.text.Length > 0)
            {
                howcha = 2;
            }
            else
            {
                howcha = 1;
            }
            float cha = chapterT.text.Length * howcha;
            chapterBG.anchoredPosition = new Vector2(-cha, chapterBG.anchoredPosition.y);

            // 턴
            turnT.text = turnCount + "턴";

            if (Input.GetKeyDown(KeyCode.R))
            {
                RUPassTurn();
            }

            // 캐릭터
            characterList[watchCharacter].transform.localScale = new Vector2(120f, 120f);

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll > 0f)
            {
                characorRe();
                if (watchCharacter == 0)
                {
                    watchCharacter = characterList.Count - 1;
                }
                else
                {
                    --watchCharacter;
                }
            }
            else if (scroll < 0f || Input.GetKeyDown(KeyCode.E))
            {
                characorRe();
                if (watchCharacter == characterList.Count - 1)
                {
                    watchCharacter = 0;
                }
                else
                {
                    ++watchCharacter;
                }
            }

            // 이벤트
            if (isEvent)
            {
                eventBg.SetActive(true);
            }
            else
            {
                eventBg.SetActive(false);
            }

            eventT.text = "다음 이벤트까지: " + eventCount + "턴";
        }

        if(PopupP.activeSelf == true)
        {
            isOK = false;
        }
        else if (PopupP.activeSelf == false)
        {
            isOK = true;
        }
    }

    void characorRe()
    {
        characterList[watchCharacter].transform.localScale = new Vector2(100f, 100f);
    }

    void RUPassTurn() // 턴 넘기겠습니까?
    {
        PopupP.SetActive(true);
    }

    public void PassTurn() // 턴 넘기기
    {
        ++turnCount;
        NOPass();
    }

    public void NOPass()
    {
        PopupP.SetActive(false);
    }
}
