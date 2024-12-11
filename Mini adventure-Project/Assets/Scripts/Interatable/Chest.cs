using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChestRarity{
    Common
}
public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public bool isOpened = false;
    public Transform closedChest, openedChest;
    public ItemManager itemManager;
    Item itemInside;
    void Start()
    {
        Transform item = Instantiate(itemManager.SpawnItem().transform, transform);
        item.position = this.transform.position;
        item.gameObject.SetActive(false);
        itemInside = item.GetComponent<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S) && Vector3.Distance(PlayerController.Instance.transform.position, this.transform.position) <= 1.2f){
            //Open chest
            isOpened = true;
            closedChest.gameObject.SetActive(false);
            openedChest.gameObject.SetActive(true);
            itemInside.gameObject.SetActive(true); 
        }
    }

}
