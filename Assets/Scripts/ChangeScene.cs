using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //Need this

public class ChangeScene : MonoBehaviour
{
    public string sceneToLoad;
   void OnTriggerEnter(Collider collision) {
       if(collision.CompareTag("Player") && !collision.isTrigger){
           SceneManager.LoadScene(sceneToLoad);
       }
   }
   /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
