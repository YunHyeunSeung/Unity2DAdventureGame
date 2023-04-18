using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portaitArr;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1" });
        talkData.Add(100, new string[] { "나는 나무상자야" });
        talkData.Add(200, new string[] { "나는 루나라고 해:0", "이 호수는 예쁘지?:1" });

        portraitData.Add(200 + 0, portaitArr[0]);
        portraitData.Add(200 + 1, portaitArr[1]);
        portraitData.Add(200 + 2, portaitArr[2]);
        portraitData.Add(200 + 3, portaitArr[3]);


        portraitData.Add(1000 + 0, portaitArr[4]);
        portraitData.Add(1000 + 1, portaitArr[5]);
        portraitData.Add(1000 + 2, portaitArr[6]);
        portraitData.Add(1000 + 3, portaitArr[7]);




    }

    public string GetTalk(int ID, int talkIndex)
    {
        if(talkIndex == talkData[ID].Length)
        {
            return null;
        }
        else
            return talkData[ID][talkIndex];
    }

    public Sprite GetPortraite(int ID, int portaitIndex)
    {
        return portraitData[ID + portaitIndex];
    }
    

}
