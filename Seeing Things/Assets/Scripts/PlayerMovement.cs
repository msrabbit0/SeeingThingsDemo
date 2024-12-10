using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]

    public float movementSpeed;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public Transform orientation;

    bool grounded;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rigidBody; 

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), playerHeight * 0.5f + 10f, whatIsGround);

        setInput();

        if (grounded)
        {
            rigidBody.drag = groundDrag;
        } else
        {
            rigidBody.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void setInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void movePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rigidBody.AddForce(moveDirection.normalized * movementSpeed * 10f);
    }
}
