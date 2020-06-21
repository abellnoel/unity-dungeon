using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    walk,
    attack,
    interact
}
public class movement : MonoBehaviour
{
    public PlayerState currentState; //can add a state machine to this later
    //variables
    public Rigidbody2D rb; 
    public float moveSpeed = 5f;
    public Animator animator;
    private Vector2 move;
    private Vector3 change;
    private float lastDirection = 1;
    public VectorValue startingPosition;

    void Start() {
        currentState = PlayerState.walk;
        rb = GetComponent<Rigidbody2D>();
        transform.position = startingPosition.initialValue;
    }
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
         
         if(Input.GetButtonDown("attack") && currentState != PlayerState.attack){
             StartCoroutine(AttackCo());
         }
         //else if(currentState == PlayerState.walk){
             //update animation and move
         //}
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

    private IEnumerator AttackCo(){
        //animator.SetBool("attacking", true); 
        currentState = PlayerState.attack;
        yield return null;
        //animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }
}

