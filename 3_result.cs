using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class result : MonoBehaviour
{

    public GameObject scoreobject;
    public float score;

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

    }
}
