using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int receivedCoin;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Die(){
        Player.Instance.collectedCoins += receivedCoin;
        Destroy(this.gameObject);
    }
}
