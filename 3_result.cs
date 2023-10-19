using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class result : MonoBehaviour
{

    public GameObject scoreobject;
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
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            menu = !menu;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            menu = !menu;
        }

        if(menu){
            start.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            ranking.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }else{
            start.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            ranking.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            if(menu){
                SceneManager.LoadScene("2_play");
            }else {
                SceneManagement.LoadScene("1_title");
            }
        }
    }
}
