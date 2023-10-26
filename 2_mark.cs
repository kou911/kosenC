using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mark : MonoBehaviour
{

    public Renderer go;
    public Renderer white;
    public float rnd;
    public float waittime;
    public static float score;
    public GameObject wood;
    public float result;
    public int key;
    public int getkey;
    public Sprite wait;
    public Sprite cut;
    public Sprite end;
    public SpriteRenderer player;
    public Sprite target;
    public Sprite becut;
    public SpriteRenderer woodsprite;

    public static float getscore() {
        return score;
    }

    IEnumerator cutin()
	{
        white.enabled = true;
        switch (getkey) {
    	    case 1:
                transform.position = new Vector3(6.5f, 1.6f, 0);
	            break;
            case 2:
                transform.position = new Vector3(6.5f, 0, 0);
	            break;
            case 3:
                transform.position = new Vector3(6.5f, -5.6f, 0);
	            break;
        }
        player.sprite = cut;
        yield return new WaitForSeconds (0.1f);
        white.enabled = false;
        yield return new WaitForSeconds (1f);
        player.sprite = end;
        yield return new WaitForSeconds (0.5f);
        if(score == -1){
            transform.eulerAngles = new Vector3(0,0,-90f);
            player.sprite = wait;
        }else {
            woodsprite.sprite = becut;
        }
        yield return new WaitForSeconds (0.5f);
        SceneManager.LoadScene("3_result");
	}

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-6f, -1.4f, 0);
        player.sprite = wait;
        getkey = 0;
        score = 0;
        white.enabled = false;
        waittime=0;
        go.enabled = false;
        rnd = Random.Range(2.00f, 5.00f);
        key = Random.Range(1,4);
        switch (key) {
		    case 1:
                wood.transform.position = new Vector3(4, 3.7f, 0);
	            break;
            case 2:
                wood.transform.position = new Vector3(4, 0, 0);
		        break;
            case 3:
                wood.transform.position = new Vector3(4, -3.7f, 0);
		        break;
	    }
    }

    // Update is called once per frame
    void Update()
    {
        waittime += Time.deltaTime;

        if(waittime >= rnd && score == 0){
            go.enabled = true;
        }


        if(getkey == 0){
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
            }else{
                score = -1;
            }
            StartCoroutine("cutin");
        }
    }
}
