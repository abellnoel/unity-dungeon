using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    const int DEFAULT_HP = 20;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        health = DEFAULT_HP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getHealth(){
        return health;
    }
}
