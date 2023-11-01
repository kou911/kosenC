using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class result : MonoBehaviour
{

    public GameObject scoreobject;
    public GameObject startobject;
    public GameObject titleobject;
    public float score;
    public bool menu;
    public bool able;

    // Start is called before the first frame update
    void Start()
    {
        score = mark.getscore();
        Text scoretext = scoreobject.GetComponent<Text> ();
        if(score == 1000){
            scoretext.text = "失敗";
        }else {
            scoretext.text = (Mathf.Floor((score + 0.0005f)*1000f)/1000f).ToString() + "秒";
        }
    }

    // Update is called once per frame
    void Update()
    {
        able = rankingtool.ok;
        Text start = startobject.GetComponent<Text> ();
        Text title = titleobject.GetComponent<Text> ();

        if(able){
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                menu = !menu;
            }

            if(menu){
                start.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                title.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }else{
                start.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                title.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            }

            if(Input.GetKeyDown(KeyCode.Return)){
                if(!menu){
                    SceneManager.LoadScene("2_play");
                }else {
                    SceneManager.LoadScene("1_title");
                }
            }
        }
    }
}
