using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    public float triggerDistance = 2f;
    public TMP_Text tmp;
    protected bool isTriggered = false;
    float distance;
    protected virtual void Update(){
        distance = Vector3.Distance(Player.Instance.transform.position, transform.position);
        if (distance <= triggerDistance){
            if (Input.GetKeyDown(KeyCode.S)){
                Trigger();
            }
            tmp.gameObject.SetActive(true);
        }
        else{
            tmp.gameObject.SetActive(false);
        }
        
    }
    protected virtual void Trigger(){
        isTriggered = true;
    }
}
