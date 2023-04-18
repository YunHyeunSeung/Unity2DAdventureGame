using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DalogManger : MonoBehaviour
{
    public Text talkText;
    public GameObject talkPanel;
    public bool isAction;
    public TalkManager talkManager;
    public Image portraitImg;

    public int talkIndex;


    GameObject scanObject;

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjecData objData = scanObject.GetComponent<ObjecData>();
        Talk(objData.ID, objData.isNpc);

        talkPanel.SetActive(isAction);
    }

    void Talk(int ID, bool isNpc)
    {
        string talkData = talkManager.GetTalk(ID, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0];

            portraitImg.sprite = talkManager.GetPortraite(ID, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;

    }
}
