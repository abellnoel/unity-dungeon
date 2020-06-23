using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust; //force character knocks things back
    public float knockTime;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if(enemy != null){
                enemy.GetComponent<EnemyAI>().currentState = EnemyState.stagger;
                //difference between player and enemy
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;//normalized makes vector with a length of one
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));
            }
        }
    }
    private IEnumerator KnockCo(Rigidbody2D enemy){
        if(enemy != null){
            Debug.Log("Knockback");
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<EnemyAI>().currentState = EnemyState.idle;
        }
    }
}
