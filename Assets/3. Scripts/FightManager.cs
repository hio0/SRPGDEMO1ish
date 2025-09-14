using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    public bool isOK;

    public TMP_Text objectiveT;
    public TMP_Text chapterT;

    public int turnCount;
    public TMP_Text turnT;

    public GameObject PopupP;

    RectTransform rec;
    public int watchCharacter;
    public int MaxCharacter;
    public List<GameObject> characterList;

    public bool isEvent;
    public GameObject eventBg;
    public int eventCount;
    public TMP_Text eventT;
    public float evnum;

    int actnum;
    public int ActionCount;
    public TMP_Text actionT;

    private void OnEnable()
    {
        isOK = true;
        watchCharacter = 0;
        //characterList = new List<GameObject>(MaxCharacter);

        PassTurn();
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
            

            // 챕터
            

            // 턴
            turnT.text = turnCount + "턴";

            if (Input.GetKeyDown(KeyCode.R))
            {
                RUPassTurn();
            }

            // 캐릭터
            rec = characterList[watchCharacter].GetComponent<RectTransform>();
            rec.sizeDelta = new Vector2(420f, 100f);

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

            if(evnum <= eventCount/3)
            {
                eventT.text = "다음 이벤트까지: " + "<color=#E01314>" + evnum.ToString() + "턴" + "</color>";
            }
            else
            {
                eventT.text = "다음 이벤트까지: " + evnum.ToString() + "턴";
            }

            // 액션
            actionT.text = "남은 행동 개수: " + "<size=50>" + ActionCount + "</size>";
            if (actnum <= ActionCount/3)
            {
                actionT.text = "남은 행동 개수: " + "<color=#E01314>" + "<size=50>" + actnum.ToString() + "</size>" + "</color>";
            }
            else
            {
                actionT.text = "남은 행동 개수: " + "<size=50>" + actnum.ToString() + "</size>";
            }

        }

        if (PopupP.activeSelf == true)
        {
            isOK = false;
            if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
            {
                PassTurn();
            }
        }
        else if (PopupP.activeSelf == false)
        {
            isOK = true;
        }
    }

    void characorRe()
    {
        rec.sizeDelta = new Vector2(350f, 85f);
    }

    public void RUPassTurn() // 턴 넘기겠습니까?
    {
        PopupP.SetActive(true);
    }

    public void PassTurn() // 턴 넘기기
    {
        ++turnCount;

        evnum = eventCount - turnCount;
        if(evnum <= 0)
        {
            evnum = 0;
            isEvent = false;
        }
        NOPass();
    }

    public void NOPass()
    {
        PopupP.SetActive(false);
    }
}
