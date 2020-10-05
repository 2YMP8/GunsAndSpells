using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{

    Animator anm;
    CharacterController controller;
    public float rotationSpeed, movementSpeed, gravity = 20;
    Vector3 movementVector = Vector3.zero;
    float desireRotationAngle = 0;
    private float inputVerticalDirection = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        anm = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        
    }

    public void HandleMovement(Vector2 input)
    {
        if (controller.isGrounded)
        {
            if(input.y != 0)
            {
                if(input.y > 0)
                {
                    inputVerticalDirection = Mathf.CeilToInt(input.y);
                }
                else
                {
                    inputVerticalDirection = Mathf.FloorToInt(input.y);
                }
                movementVector = input.y * transform.forward * movementSpeed;
            }
            else
            {
                movementVector = Vector3.zero;
                anm.SetFloat("move", 0);
            }
        }
    }

    public void HanleMovementDirection(Vector3 direction)
    {
        desireRotationAngle = Vector3.Angle(transform.forward, direction);
        var crossProduct = Vector3.Cross(transform.forward , direction).y;
        if (crossProduct < 0)
        {
            desireRotationAngle *= -1;
        }
    }
    
    void RotateAgent()
    {
        if (desireRotationAngle > 10 || desireRotationAngle < -10)
        {
            transform.Rotate(Vector3.up * desireRotationAngle * rotationSpeed * Time.deltaTime);
        }
    }
    private float SetCorrectAnimation(float inputVerticalDirection)
    {
        float currentAnimationSpeed = anm.GetFloat("move");
        if(desireRotationAngle > 10 || desireRotationAngle < -10)
        {
            if(Mathf.Abs(currentAnimationSpeed) < 0.2f)
            {
                currentAnimationSpeed += inputVerticalDirection *  Time.deltaTime * 2;
                currentAnimationSpeed = Mathf.Clamp(currentAnimationSpeed, -0.2f, 0.2f);
            }
            anm.SetFloat("move", currentAnimationSpeed);
        }
        else
        {
            if (currentAnimationSpeed < 1)
            {
                currentAnimationSpeed += inputVerticalDirection * Time.deltaTime * 2;
            }
            
            anm.SetFloat("move",Mathf.Clamp( currentAnimationSpeed, -1,1));
        }
        return Mathf.Abs (currentAnimationSpeed);
    }
    // Update is called once per frame
    void Update()
    {


        

       

       if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Run");
            anm.SetBool("isRunning", true);
        }
        else
        {
            anm.SetBool("isRunning", false);
        }
        if (controller.isGrounded)
        {
            if(movementVector.magnitude > 0)
            {
                var animationSpeedMultiplier = SetCorrectAnimation(inputVerticalDirection);
                RotateAgent();
                movementVector *= animationSpeedMultiplier;
            }
        }
        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            anm.SetTrigger("isJumping");
            movementVector.y = 1100 * Time.deltaTime;
        }
        movementVector.y -= gravity * 2 ;
        controller.Move(movementVector * Time.deltaTime);
    }
}
