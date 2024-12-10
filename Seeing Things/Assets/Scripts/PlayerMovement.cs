using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements;

//Aubrey Luu
//Fall Yale CS100
public class Player : MonoBehaviour
{
    [Header("Movement")]

    public float movementSpeed;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public Transform orientation;
    public GameObject footstepsObject;

    bool grounded;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rigidBody;
    AudioSource footstepsAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        footstepsAudioSource = footstepsObject.GetComponent<AudioSource>();

        rigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    //check for ground every frame
    void Update()
    {
        //checks if player is on the ground
        grounded = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), playerHeight * 0.5f + 1f, whatIsGround);

        setInput();

        limitHorizontalVelocity();

        //apply drag ONLY if character is on the ground
        if (grounded)
        {
            rigidBody.drag = groundDrag;
        } else
        {
            rigidBody.drag = 0;
        }

        //footsteps
        Vector3 horizontalVel = new Vector3(rigidBody.velocity.x, 0f, rigidBody.velocity.z);

        if (horizontalVel.magnitude > 0f && grounded && footstepsAudioSource.mute)
        {
            footstepsAudioSource.mute = false;
        } else if (!footstepsAudioSource.mute)
        {
           footstepsAudioSource.mute = true;
        }
    }

    //check player movement every frame
    private void FixedUpdate()
    {
        movePlayer();
    }

    //sets player input
    private void setInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    //sets move direction of player
    private void movePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rigidBody.AddForce(moveDirection.normalized * movementSpeed * 10f);
    }
    
    //limits horizontal velocity
    private void limitHorizontalVelocity()
    {
        Vector3 horizontalVel = new Vector3(rigidBody.velocity.x, 0f, rigidBody.velocity.z);

        if (horizontalVel.magnitude > movementSpeed )
        {
            Vector3 limitedVel = horizontalVel.normalized * movementSpeed;
            rigidBody.velocity = new Vector3(limitedVel.x, rigidBody.velocity.y, limitedVel.y);
        }
    }
}
