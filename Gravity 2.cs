using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPersonMovment : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;


    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    
    //Gravity
    private Vector3 velocity;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    // Jump
    [SerializeField] private float jumpHeight;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {              
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0,0, moveZ);
        moveDirection *= moveSpeed;
        
        if(isGrounded)
        {

             if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) 
                {
                    Walk();
                }
                else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
                    {
                        Run();
                    }
                else if(moveDirection == Vector3.zero) 
                    {
                        Idle();
                    }

            moveDirection *= moveSpeed;

            if(Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        Debug.Log(isGrounded);
        Debug.Log(moveDirection);

    }

    private void Idle(){

    }
    private void Walk()
    {
        moveSpeed = walkSpeed; //moveSpeed is container
    }
    private void Run()
    {
        moveSpeed = runSpeed;
    }

    private void Jump()
    {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
    
}
