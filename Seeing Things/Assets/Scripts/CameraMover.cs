using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aubrey Luu
//Fall Yale CS100
public class CameraHolder : MonoBehaviour
    //Moves the camera alongside the player character
{
    // Start is called before the first frame update
    public Transform cameraPosition;

    void Start()
    {
        transform.position = cameraPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position; //camera follows player
    }
}
