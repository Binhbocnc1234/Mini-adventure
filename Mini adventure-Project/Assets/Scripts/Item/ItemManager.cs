using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    // Start is called before the first frame update
    public List<Item> itemList = new List<Item>();
    private int totalSpawnRate;
    void Start()
    {
        foreach(Transform child in this.transform){
            Item item = child.GetComponent<Item>();
            itemList.Add(item);
            item.gameObject.SetActive(false);
            totalSpawnRate += item.spawnRate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Item SpawnItem(){
        int randNum = Random.Range(0, totalSpawnRate);
        int current = 0;
        foreach(Item item in itemList){
            if (current <= randNum && randNum <= current + item.spawnRate){
                return item;
            }
            current += item.spawnRate;
        }
        Debug.LogError("Cannot find a proper item!");
        return null;
    }
}
