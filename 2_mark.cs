using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mark : MonoBehaviour
{

    public SpriteRenderer go;
    public float rnd;
    public float waittime;
    public float score;
    public GameObject needkey;
    public static string result;
    public int key;
    public int getkey;

    // Start is called before the first frame update
    void Start()
    {
        waittime=0;
        rnd = Random.Range(2.00f, 5.00f);
        key = Random.Range(1,4);
        result = "";
    }

    // Update is called once per frame
    void Update()
    {
        Text keytext = needkey.GetComponent<Text> ();
        RectTransform rect = needkey.GetComponent <RectTransform> ();

        waittime += Time.deltaTime;

        if(waittime >= rnd){
            go.enabled = true;
            switch (key) {
		        case 1:
                    rect.localPosition = new Vector3(-100, 0, 0);
			        keytext.text = "A";
			        break;
		        case 2:
                    rect.localPosition = new Vector3(0, 0, 0);
			        keytext.text = "S";
			        break;
                case 3:
                    rect.localPosition = new Vector3(100, 0, 0);
			        keytext.text = "D";
			        break;
	        }
        }


        if(go.enabled){
            if(Input.GetKeyDown(KeyCode.A)){
                getkey = 1;
            }
            if(Input.GetKeyDown(KeyCode.S)){
                getkey = 2;
            }
            if(Input.GetKeyDown(KeyCode.D)){
                getkey = 3;
            }
        }

        if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))){
            if(go.enabled && getkey == key){
                score = Mathf.Floor((waittime - rnd + 0.0005f)*1000f)/1000f;
                result = score.ToString() + "秒";
                keytext.text = "";
            }else{
                result = "失敗";
                keytext.text = "";
            }

            waittime = 0;
            go.enabled = false;
        }

    }
}
