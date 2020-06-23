using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}

public class EnemyAI : MonoBehaviour //AI for every enemy
{
    public EnemyState currentState;
    public int health;
    public float moveSpeed;
    public string enemyName;
    public int baseAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
