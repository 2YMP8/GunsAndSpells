using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    Iinput input;
    AgentController movement;
    // Start is called before the first frame update
    void OnEnable()
    {
        movement = GetComponent<AgentController>();
        input = GetComponent<Iinput>();
        input.OnMovementDirectionInput += movement.HanleMovementDirection;
        input.OnMovementInput += movement.HandleMovement;
    }
    private void OnDisable()
    {
        input.OnMovementDirectionInput -= movement.HanleMovementDirection;
        input.OnMovementInput -= movement.HandleMovement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
