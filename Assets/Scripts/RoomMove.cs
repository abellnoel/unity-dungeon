using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    /*
    This class is just going to make the camera transition
    from one room to the next smoothly. This is not changing
    the scene, I just made a seperate tilemap and connected
    them for this.

    Also note that this only works for square rooms, anything
    else would require another vector for change
    */
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;

    public bool needText; //Not every room needs a title card
    public string placeName;
    public GameObject text;
    public Text placeText;

    private Coroutine lastMessage = null;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange; //Moving the player where they need to be

            //removes text when moving rooms no matter if the next room has text or not
            StopAllCoroutines(); //STOP ALL COROUTINES ON THIS MONOBEHAVIOR/SCRIPT
            text.SetActive(false); //stop showing current text
            if (needText) { 
                StartCoroutine(placeNameCo()); //executes function along a sequence of frames rather than one frame
            }
        }
    }
    private IEnumerator placeNameCo(){ //IEnumerator allows you to have a specified wait time
        placeText.text = placeName; //Title
        text.SetActive(true);//Text on 
        yield return new WaitForSeconds(4f); //rather than resuming after the next frame, the coroutine resumes after time
        text.SetActive(false); //The text is no longer on screen
    } 
}
