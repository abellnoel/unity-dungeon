using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    
    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            LoadNextLevel();
        }
    }
    public void LoadNextLevel(){
        StartCoroutine(LoadScene(SceneManager.GetActiveScene()
                               .buildIndex + 1));
        
    }

    IEnumerator LoadScene(int sceneIndex){
        //Play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load Scene    
        SceneManager.LoadScene(sceneIndex);
    }
}
