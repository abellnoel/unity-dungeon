using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health = 100f;
    public void RemoveHealth(float amount){
        health -= amount;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
