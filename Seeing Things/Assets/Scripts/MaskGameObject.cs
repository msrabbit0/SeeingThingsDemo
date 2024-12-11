using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aubrey Luu
//Fall Yale CS100
//Script belonging to the in game mask object
public class MaskGameObject : MonoBehaviour
{
    public GameObject maskSystemObject;
    public bool acquired;
    //Click to pick up
    void OnMouseDown()
    {
        if (!acquired)
        {
            maskSystemObject.GetComponent<MaskSystem>().maskAcquired = true;
            transform.position = new Vector3(0, 10000f, 0); //bye

            acquired = true;
        }
    }

}
