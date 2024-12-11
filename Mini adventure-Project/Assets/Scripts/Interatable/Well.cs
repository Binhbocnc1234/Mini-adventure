using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Well : Interactable
{
    // Start is called before the first frame update
    public bool isPlayed = false;
    public bool isPray = false;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) <= 2f){
            tmp.gameObject.SetActive(true);
            if (Input.GetKeyUp(KeyCode.S)){
                if (isPlayed){
                    tmp.text = "I'm out of money :( Come back later";
                    return;
                }
                if (Player.Instance.collectedCoins == 0){
                    tmp.text = "To make a prayer. You should have coins in your bag";
                }
                Player.Instance.collectedCoins -= 1;
                int receivedCoin = Random.Range(0, 10);
                isPray = true;
                animator.speed = 1;
                animator.Play("Slime");
                if (receivedCoin <= 8){
                    tmp.text = "Oops, this time you seem a bit unlucky. Try again?";
                }
                else{
                    tmp.text = "JACKPOTT!. You received 8 coins";
                    Player.Instance.collectedCoins += 8;
                    isPlayed  = true;
                }
            }
        }
        else{
            tmp.gameObject.SetActive(false);
        }
    }
    public void EndAnimation(){
        animator.speed = 0;
    }
}
