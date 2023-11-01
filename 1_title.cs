using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{

    public GameObject starttext;
    public GameObject rankingtext;
    public bool menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text start = starttext.GetComponent<Text>();
        Text ranking = rankingtext.GetComponent<Text>();

        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)){
            menu = !menu;
        }

        if(menu){
            start.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            ranking.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }else{
            start.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            ranking.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            if(!menu){
                SceneManager.LoadScene("2_play");
            }else {
                SceneManager.LoadScene("4_ranking");
            }
        }
    }
}
