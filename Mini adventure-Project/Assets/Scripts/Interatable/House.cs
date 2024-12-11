using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class House : MonoBehaviour
{
    private Worship worshipScence;
    public TMP_Text invitation_tmp;
    public bool visited = false;
    // public int actionInd = 0;
    // private List<string> actions = new List<string>(){"EnterHouse", ""}
    void Start()
    {
        worshipScence = Worship.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) <= 3f){
            invitation_tmp.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.S) && visited == false){
                worshipScence.gameObject.SetActive(true);
                Player.Instance.initialPosition = this.transform.position;
                visited = true;
                invitation_tmp.text = "If you passed away, you will revive in our house";
            }
        }
        else{
            invitation_tmp.gameObject.SetActive(false);
        }
    }
    void EnterHouse(){
        
    }
}
