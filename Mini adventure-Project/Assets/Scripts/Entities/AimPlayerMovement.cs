using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AimPlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float triggerDistance = 10f;
    public float moveSpeed = 3f;
    private float stopDistance = 2.5f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(Player.Instance.transform.position, this.transform.position);
        if (distance <= triggerDistance && distance >= stopDistance){
            float direction = Player.Instance.transform.position.x > transform.position.x ? 1f : -1f;
            transform.Translate(new Vector3(direction*moveSpeed*Time.deltaTime, 0, 0));
        }
    }
}
