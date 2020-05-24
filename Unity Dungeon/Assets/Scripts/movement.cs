using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //variables
    public Rigidbody2D rb; 
    private Vector2 move;
    public float moveSpeed = 5f; 

    // Update is called once per frame
    void Update()
    {   
        //between -1 and 1
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
    }

    // Called once per fixed amount of time, more consistent for physics
    void FixedUpdate()
    {
        //multiply by fixedDeltaTime for more consistency
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime); //Vector2 supports multiplacation by floats but not doubles 
    }
}

