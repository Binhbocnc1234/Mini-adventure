using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvent : MonoBehaviour
{
    private PlayerController plController;
    private Player player;
    void Start(){
        player = Player.Instance;
        plController = PlayerController.Instance;
    }
    public void EndAttack(){
        plController.plState = PlayerState.None;
        player.EndAttack();

    }
    // public void StartAttack(){
    //     player.Start
    // }
    public void StartAttack(){

    }
}
