using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Worship : Singleton<Worship>
{
    public string fullText = "O ancestors who rest in the sacred place,\nPlease listen to our prayers.\nWe offer this gift in gratitude.\nPlease bless this land with prosperity,\nGive us strength to face the darkness,\nAnd guide us on the path of righteousness.";
    public TMP_Text pray_tmp;
    string curText = "";
    int ind = 0;
    Timer delayChar = new Timer(0.02f);
    void OnEnable(){
        curText = "";
        ind = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (delayChar.Count() && ind < fullText.Length){
            curText += fullText[ind];
            ind++;
            pray_tmp.text = curText;
        }
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Player finished worship ritual");
            this.gameObject.SetActive(false);
        }
    }
    
}
