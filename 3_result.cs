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

    // Start is called before the first frame update
    void Start()
    {
        score = mark.getscore();
        Text scoretext = scoreobject.GetComponent<Text> ();
        if(score == -1){
            scoretext.text = "失敗";
        }else {
            scoretext.text = score.ToString() + "秒";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Text start = startobject.GetComponent<Text> ();
        Text title = titleobject.GetComponent<Text> ();

        if(Input.GetKey(KeyCode.UpArrow)){
            menu = !menu;
            print("a");
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            menu = !menu;
        }

        if(menu){
            start.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            title.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }else{
            start.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            title.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }

        if(Input.GetKey(KeyCode.Return)){
            if(menu){
                SceneManager.LoadScene("2_play");
            }else {
                SceneManager.LoadScene("1_title");
            }
        }
    }
}
