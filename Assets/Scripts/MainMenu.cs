using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){//Basically starts the game
        SceneManager.LoadScene(SceneManager.GetActiveScene()
                               .buildIndex + 1); //Getting the next
                                                 // Scene in the queue
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit");
    }
}
