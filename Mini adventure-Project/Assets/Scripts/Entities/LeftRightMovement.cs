using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LRMovementState{
    StandStill,
    Moving
}
[RequireComponent(typeof(Flip))]
public class LeftRightMovement : MonoBehaviour
{
    public LRMovementState state = LRMovementState.Moving;
    public float leftBorder, rightBorder;
    private float initialPosX;
    public float standStillTime = 4f;
    public float velocity = 5f;
    Flip flip;
    Rigidbody2D rb;
    Timer timer;
    void Start()
    {
        timer = new Timer(standStillTime);
        rb = GetComponent<Rigidbody2D>();
        flip = GetComponent<Flip>();
        initialPosX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (transform.position.x >= rightBorder + initialPosX && flip.facingRight == true){
            state = LRMovementState.StandStill;
            flip.ChangeDirection();
        }
        else if (transform.position.x <= leftBorder + initialPosX && flip.facingRight == false){
            state = LRMovementState.StandStill;
            flip.ChangeDirection();
        }
        else{
            state = LRMovementState.Moving;
            float v;
            if (flip.facingRight){
                v = velocity;
            }
            else{
                v = -velocity;
            }
            transform.Translate(new Vector3(Time.deltaTime*v, 0, 0));
        }
    }
    
}
