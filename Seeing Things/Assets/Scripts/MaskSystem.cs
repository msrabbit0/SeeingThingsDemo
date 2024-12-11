using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.PostProcessing;


//Aubrey Luu
//Fall Yale CS100
//Handles functionality of the mask

public class MaskSystem : MonoBehaviour
{

    [Header("Mask")]
    public bool maskAcquired;
    public bool maskOn;
    public GameObject maskBreathingSound;
    public GameObject maskEquipSound;
    public KeyCode equipBind;
    public bool firstWear;
    public GameObject spawnDoor;


    [Header("Game World")]
    public GameObject realWorld;
    public GameObject fakeWorld;
    public GameObject globalVolume;
    public GameObject menuUi;



    // Start is called before the first frame update
    void Start()
    {
        maskAcquired = false;
        maskOn = false;

        showFakeWorld(); //start without mask
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

    //toggles the mask and its effects
    void toggleMask()
    {
        if (firstWear)
        {
            menuUi.SetActive(false);
            firstWear = false;
            spawnDoor.SetActive(false);
        }

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
