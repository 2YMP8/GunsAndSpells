using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveWithAnm : MonoBehaviour
{
    Animator anm;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        anm = gameObject.GetComponent<Animator>();
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            anm.SetBool("isRunning", true);
            
        }
        else
        {
            anm.SetBool("isRunning", false);
        }
    }
   
}
