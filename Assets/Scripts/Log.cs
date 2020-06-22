using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : EnemyAI //inheritance of enemyAI
{
    public Transform target;
    public float chaseRadius; //if player is close enough it will chase
    public float attackRadius; //attack the player
    public Transform homePosition;//Where the enemy goes back to

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //gets location of player
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance(){
        if(Vector3.Distance(target.position, transform.position)
                             <= chaseRadius
        && Vector3.Distance(target.position, transform.position)
                             > attackRadius){ 
                                 
        /*This ^^ checks the distance between player and the log
        to see if the log should chase the enemy
        Logically, you only want to chase if the player is inbetween
        the move and the attack radius
        */
            transform.position = Vector3.MoveTowards(transform.position,
                                                    target.position,
                                                    moveSpeed * Time.deltaTime);
        }
    }
}
