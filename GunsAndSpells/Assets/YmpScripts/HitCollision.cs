using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollision : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand") && other.gameObject != this.gameObject)
        {
            anim.SetTrigger("Hit");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FireAttak"))
        {
            anim.SetTrigger("Hit");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("IceAttack"))
        {
            anim.SetTrigger("Hit");
            Destroy(collision.gameObject);
        }
    }
}
