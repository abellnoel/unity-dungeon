using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing; // Makes the camera smoothly catch up to player

    public Vector2 maxPosition; //These to keep the camera in the game
    public Vector2 minPosition; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position != target.position)//The player is the transform. 
                                                //This keeps it on the player
        {
            Vector3 targetPosition = new Vector3(target.position.x,
                                                 target.position.y,
                                                 transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x,//Clamps the camera in the map
                                            minPosition.x,
                                            maxPosition.x);

            targetPosition.y = Mathf.Clamp(targetPosition.y, //Clamps the camera in the map
                                            minPosition.y,
                                            maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, //Lerp is something idk
                                                   targetPosition, smoothing);
            
        }
    }
}
