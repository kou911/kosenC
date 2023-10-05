using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mark : MonoBehaviour
{

    public SpriteRenderer go;
    public SpriteRenderer title;
    public float rnd;
    public float waittime;
    public float score;
    public GameObject score_object;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

        Text scoretext = score_object.GetComponent<Text> ();

        if(Input.GetKey(KeyCode.A) && title.enabled){
            title.enabled = false;
            rnd = Random.Range(2.00f, 5.00f);
            scoretext.text = "";
        }

        if(!title.enabled){
            waittime += Time.deltaTime;
        }

        if(waittime >= rnd){
            go.enabled = true;
        }

        if(Input.GetKey(KeyCode.S) && !title.enabled){
            title.enabled = true;

            if(go.enabled){
                score = waittime - rnd;
                scoretext.text = score.ToString() + "秒";
            }

            else{
                scoretext.text = "失敗";
            }

            waittime = 0;
            go.enabled = false;
        }
    }
}
