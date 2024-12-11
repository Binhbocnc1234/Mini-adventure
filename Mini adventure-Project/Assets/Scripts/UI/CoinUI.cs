using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public TMP_Text tmp_health;
    public TMP_Text tmp_coin;
    void Update(){
        tmp_health.text = Player.Instance.GetComponent<Entity>().health.ToString();
        tmp_coin.text = Player.Instance.collectedCoins.ToString();
    }
}
