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
            if(needText){
                StartCoroutine(placeNameCo()); //Not sure how this works
            }
        }
    }
    private IEnumerator placeNameCo(){ //IEnumerator allows you to have a specified wait time
        text.SetActive(true);//Text on screen
        placeText.text = placeName; //Title
        yield return new WaitForSeconds(2f); //text Waits a bit before leaving
        text.SetActive(false); //The text is no longer on screen
    } 
}
