using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;

public class Mask : MonoBehaviour
{
    //Handles functionality of the mask
    [Header("Mask")]
    public bool maskAcquired;
    public bool maskOn;
    public GameObject maskBreathingSound;
    public GameObject maskEquipSound;
    public KeyCode equipBind;

    [Header("Game World")]
    public GameObject realWorld;
    public GameObject fakeWorld;
    public GameObject globalVolume;


    // Start is called before the first frame update
    void Start()
    {
        maskAcquired = true;
        maskOn = false;

        showFakeWorld();
    }

    // Update is called once per frame
    void Update()
    {
        if (maskAcquired)
        {
            if (Input.GetKeyDown(equipBind)) // put on mask
            {
                toggleMask();
            }
        }

    }

    void toggleMask()
    {
        if (maskOn) //unequip mask
        {
            showFakeWorld();
            maskBreathingSound.GetComponent<AudioSource>().mute = true;  
        }
        else //equip mask
        {
            showRealWorld();
            maskBreathingSound.GetComponent<AudioSource>().mute = false;
        }

        maskOn = !maskOn;
        maskEquipSound.GetComponent<AudioSource>().Play();

    }

    void showFakeWorld()
    {
        fakeWorld.SetActive(true);
        realWorld.SetActive(false);
        globalVolume.SetActive(false);
    }

    void showRealWorld()
    {
        realWorld.SetActive(true);
        fakeWorld.SetActive(false);
        globalVolume.SetActive(true);
    }

}
