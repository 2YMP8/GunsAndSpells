using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody rb;
    public float _platformBoardForce;

    public GameObject Cemetery;
    public GameObject Factory;
    public GameObject Houses;


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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GraveColider")
        {
            Cemetery.SetActive(true);
        }
        if (other.gameObject.tag == "FactoryColider")
        {
            Factory.SetActive(true);
        }
        if (other.gameObject.tag == "HousesColider")
        {
            Houses.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "GraveColider")
        {
            Cemetery.SetActive(true);
        }
        if (other.gameObject.tag == "FactoryColider")
        {
            Factory.SetActive(true);
        }
        if (other.gameObject.tag == "HousesColider")
        {
            Houses.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GraveColider")
        {
            Cemetery.SetActive(false);
        }
        if (other.gameObject.tag == "FactoryColider")
        {
            Factory.SetActive(false);
        }
        if (other.gameObject.tag == "HousesColider")
        {
            Houses.SetActive(false);
        }
    }

}
