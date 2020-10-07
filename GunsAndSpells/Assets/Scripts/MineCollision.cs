using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCollision : MonoBehaviour
{
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            explosion.SetActive(true);
            WaitSeconds();
            explosion.SetActive(false);


        }
    }

    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(2);
    }
}
