using System;
using UnityEngine;
using UnityEngine.UI;

public class rankingtool : MonoBehaviour {

    int point = 1;

    string[] ranking = { "1位", "2位", "3位", "4位", "5位", "6位", "7位", "8位", "9位", "10位" };
    int[] rankingValue = new int[10];
    Text[] rankingText = new Text[10];
    // Use this for initialization
    void OnClick()
    {
        GetRanking();

        SetRanking(point);

        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = rankingValue[i].ToString();
        }
        Debug.Log(rankingText);
    }


    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i]=PlayerPrefs.GetInt(ranking[i]);
        }
    }

    void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < ranking.Length; i++)
        {
                if (_value>rankingValue[i])
                {
                    var change = rankingValue[i];
                    rankingValue[i] = _value;
                    _value = change;
                }
        }

        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i],rankingValue[i]);
        }
    }
}

