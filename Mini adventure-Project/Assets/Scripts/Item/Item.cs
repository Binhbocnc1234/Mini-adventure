using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    public int spawnRate = 0;
    public Transform realObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player press key S to pick up item
        if (Input.GetKeyUp(KeyCode.S) && Vector3.Distance(PlayerController.Instance.transform.position, this.transform.position) <= 1.2f){
            Debug.Log("Player picks up weapon");
            Player.Instance.ChangeWeapon(realObject.GetComponent<Weapon>());
        }
    }
}
