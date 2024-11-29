using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StoryManager : MonoBehaviour
{
    List<RectTransform> scenceList = new List<RectTransform>();
    private int index = 0;
    void Start(){
        //Add scence to scenceList
        foreach(RectTransform child in this.GetComponent<RectTransform>()){
            scenceList.Add(child);
            child.gameObject.SetActive(false);
        }
        scenceList[0].gameObject.SetActive(true);
    }
    void Update()
    {
        // Left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button pressed");
            MoveScence();
        }

        // Right mouse button click
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right mouse button pressed");
        }

        // Middle mouse button click
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Middle mouse button pressed");
        }
    }
    void MoveScence(){
        if (index == scenceList.Count - 1){
            SceneManager.LoadScene("Lobby");
        }
        scenceList[index].gameObject.SetActive(false);
        index++;
        scenceList[index].gameObject.SetActive(true);
    }
}
