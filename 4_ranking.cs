using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ranker : MonoBehaviour
{
    public string[] ranking = { "1位", "2位", "3位", "4位", "5位", "6位", "7位", "8位", "9位", "10位" };
    public GameObject rankobject;
    public float[] rankingValue = new float[10];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i]=PlayerPrefs.GetFloat(ranking[i]);
        }
        Text rankbd = rankobject.GetComponent<Text> ();
        rankbd.text = ""; 
        for (int i = 0; i < ranking.Length; i++)
        {
            rankbd.text += ranking[i];
            rankbd.text += " " + PlayerPrefs.GetString(rankingValue[i].ToString());
            rankbd.text += " " + rankingValue[i].ToString() + "秒\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("1_title");
        }
    }
}
