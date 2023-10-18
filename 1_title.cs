using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{

    public GameObject starttext;
    public GameObject rankingtext;
    public int menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text start = starttext.GetComponent<Text>();
        Text ranking = rankingtext.GetComponent<Text>();

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            menu = 1;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            menu = 2;
        }

        if(menu == 1){
            start.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            ranking.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }else if(menu == 2){
            start.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            ranking.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            if(menu == 1){
                SceneManager.LoadScene("2_play");
            }
        }
    }
}
