using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    protected Player player;
    public int rotateSpeed = 10;
    void Start()
    {
        player = Player.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 pos = transform.rotation.;
        // pos.z = (pos.z + rotateSpeed*Time.deltaTime) % 360;
        // transform.position = pos;
        transform.Rotate(new Vector3(0, rotateSpeed*Time.deltaTime, 0));
        // Debug.Log(Vector3.Distance(player.transform.position, this.transform.position));
        if (Vector3.Distance(player.transform.position, this.transform.position) <= 1.5f){
            player.collectedCoins += 1;
            Destroy(this.gameObject);
        }
    }
}
