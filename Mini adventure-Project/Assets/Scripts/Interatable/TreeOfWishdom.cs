using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOfWishdom : Interactable
{
    public int receivedHealth = 100;
    protected override void Trigger()
    {

        
        if (isTriggered == false){
            Player.Instance.GetComponent<Entity>().health += receivedHealth;
        }
        else{
            tmp.text = "I've given you all my wishdom";
        }
        base.Trigger();
    }
}
