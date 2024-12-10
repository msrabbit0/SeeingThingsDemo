using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public GameObject chaser;
    public GameObject victim;

    // Start is called before the first frame update
    void Start()
    {
        chaser.transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        chaser.transform.position = Vector3.MoveTowards(chaser.transform.position, victim.transform.position, speed);
    }
}
