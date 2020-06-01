using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //variables
    public Rigidbody2D rb; 
    public float moveSpeed = 5f;
    public Animator animator;
    private Vector2 move;
    private float lastDirection = 1;

    // Update is called once per frame
    void Update()
    {   
        //between -1 and 1
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        //update animator values
        if (move.x != 0)
            lastDirection = move.x;
        animator.SetFloat("lastDirection", lastDirection);
        animator.SetFloat("isMoving", move.sqrMagnitude); //not entirely sure how this works

    }

    // Called once per fixed amount of time, more consistent for physics
    void FixedUpdate()
    {
        //multiply by fixedDeltaTime for more consistency
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime); //Vector2 supports multiplacation by floats but not doubles 
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Worked");
    }
}

