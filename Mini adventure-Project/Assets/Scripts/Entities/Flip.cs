using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flip : MonoBehaviour
{
    public bool facingRight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeDirection()
    {
        facingRight = !facingRight;
        // Flip the character by inverting its X scale
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the X-axis
        transform.localScale = scale;
    }
}
