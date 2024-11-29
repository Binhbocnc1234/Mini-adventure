using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public bool isOpened = false;
    public Transform closedChest, openedChest;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S) && Vector3.Distance(PlayerController.Instance.transform.position, this.transform.position) <= 1.2f){
            //Open chest
            closedChest.gameObject.SetActive(false);
            openedChest.gameObject.SetActive(true);

        }
    }

}
