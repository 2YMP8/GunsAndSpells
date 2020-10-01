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
            if(input.y > 0)
            {
                movementVector = transform.forward * movementSpeed;
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
        var crossProduct = Vector3.Cross(transform.forward, direction).y;
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
    private float SetCorrectAnimation()
    {
        float currentAnimationSpeed = anm.GetFloat("move");
        if(desireRotationAngle > 10 || desireRotationAngle < -10)
        {
            if(currentAnimationSpeed < 0.2f)
            {
                currentAnimationSpeed += Time.deltaTime * 2;
                currentAnimationSpeed = Mathf.Clamp(currentAnimationSpeed, 0, 0.2f);
            }
            anm.SetFloat("move", currentAnimationSpeed);
        }
        else
        {
            if (currentAnimationSpeed < 1)
            {
                currentAnimationSpeed += Time.deltaTime * 2;
            }
            else
            {
                currentAnimationSpeed = 1;
            }
            anm.SetFloat("move", currentAnimationSpeed);
        }
        return currentAnimationSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anm.SetTrigger("isJumping");
        }

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
                var animationSpeedMultiplier = SetCorrectAnimation();
                RotateAgent();
                movementVector *= animationSpeedMultiplier;
            }
        }
        movementVector.y -= gravity;
        controller.Move(movementVector * Time.deltaTime);
    }
}
