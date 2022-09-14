using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPersonMovment : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;


    public float speed = 6f;
    public float runSpeedMultiplier = 2f;
    public float turnSmooth = 0.1f;
    float   turnSmoothVelocity;
// Gravity
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private Transform groundCheck;
    private Vector3 velocity;
//Jumping
    [SerializeField] private float jumpHeight;
//


    // Update is called once per frame
    void Update()
    {
       //////////////Gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
            if(controller.isGrounded && velocity.y < 0)
                {
                    velocity.y = -2f;
                }
        ////////////////////////////////////////////////////////////////

        //Camera and movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;  //0 Y axis
        
        if(direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmooth );
                transform.rotation = Quaternion.Euler(0f, angle, 0f); //

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                if(controller.isGrounded)
                {
                        if(Input.GetKey(KeyCode.Space)) Jump();  
                         

                    if(direction != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)){
                                controller.Move(moveDir.normalized * speed * Time.deltaTime);  // Time.deltaTime nie zaleznie od framerate'u
                            }
                    else if(direction != Vector3.zero && Input.GetKey(KeyCode.LeftShift)){
                                controller.Move(moveDir.normalized * (runSpeedMultiplier * speed) * Time.deltaTime);  // Time.deltaTime nie zaleznie od framerate'u
                            }
                
                velocity.y += gravity * Time.deltaTime;
                controller.Move(velocity * Time.deltaTime);
                }    
                
            }
    }

    private void Move()
    {
    }


    private void Jump(){

        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
    
}
