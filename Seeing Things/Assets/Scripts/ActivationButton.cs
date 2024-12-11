using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the activation of the ending door on the third puzzle
public class ActivationButton : MonoBehaviour
{
    [Header("Button")]
    public GameObject playerBody; //body of player character
    public float range; // max range between body and button for the button to activate
    public bool activated;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(true);
    }

    void OnMouseDown()
    {
        if (!activated)
        {
            float dif = (playerBody.transform.position - transform.position).magnitude; //dist between body and button

            if (range >= dif)
            {
                activated = true;
                door.SetActive(false);
            }
        }
    }
}
