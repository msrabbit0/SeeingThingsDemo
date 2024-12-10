using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationButton : MonoBehaviour
{
    [Header("Button")]
    public GameObject playerBody;
    public float range;
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
            float dif = (playerBody.transform.position - transform.position).magnitude;

            if (range >= dif)
            {
                activated = true;
                door.SetActive(false);
            }
        }
    }
}
