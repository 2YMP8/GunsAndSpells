using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody rb;
    public float _platformBoardForce;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _platformBoardForce = 15000;

    }

 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("JumpingBoard"))
        {
            rb.AddForce(transform.up * _platformBoardForce * Time.deltaTime);
        }

        if (collision.gameObject.tag == "Trap")
        {
            BarsEngine.lifeCount -= 10;
        }

    }
}
