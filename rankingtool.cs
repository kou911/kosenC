using System;
using UnityEngine;
using UnityEngine.UI;

public class rankingtool : MonoBehaviour {

    public float point;

    public string[] ranking = { "1位", "2位", "3位", "4位", "5位", "6位", "7位", "8位", "9位", "10位" };

    public float[] rankingValue = new float[10];
    public GameObject rankobject;
    public bool first;
    public static bool ok;
    public InputField inputField;
    public GameObject namearea;

    void Start()
    {
        ok = true;
        GetRanking();

        point = mark.getscore();
        SetRanking(point);

        Text rank = rankobject.GetComponent<Text> ();
        rank.text = "";

        for (int i = 0; i < 3; i++)
        {
                rank.text += ranking[i] + " ";
                if(point != rankingValue[i]){
                    rank.text += PlayerPrefs.GetString(rankingValue[i].ToString());
                }else{
                    rank.text += "YOU";
                }
                rank.text += " " + (Mathf.Floor((rankingValue[i] + 0.0005f)*1000f)/1000f).ToString() + "秒";
                rank.text += "\n";
        }
    }

    void Update(){
        namearea.SetActive(!ok);
        if(Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.S)){
            for(int i = 0; i < ranking.Length; i++){
                rankingValue[i] = 0.5f + 0.1f*i;
                PlayerPrefs.SetFloat(ranking[i],rankingValue[i]);
                PlayerPrefs.SetString(rankingValue[i].ToString(),(i+1).ToString()+"位君");
            }
        }
    }

    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i]=PlayerPrefs.GetFloat(ranking[i]);
        }
    }

    void SetRanking(float _value)
    {
        first = true;
        //書き込み用
        for (int i = 0; i < ranking.Length; i++)
        {
                if (_value<rankingValue[i])
                {
                    var change = rankingValue[i];
                    rankingValue[i] = _value;
                    _value = change;
                    if(first){
                        ok = false;
                    }
                }
        }

        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetFloat(ranking[i],rankingValue[i]);
        }
    }

    public void GetInputName()
    {
        //InputFieldからテキスト情報を取得する
        string name = inputField.text;
        PlayerPrefs.SetString(point.ToString(),name);
        Invoke("Bool", 0.5f);
    }

    public void Bool(){
        ok = true;
    }
}

