using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCollision : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameObject _explosion;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {

           _explosion =  Instantiate(explosionPrefab, transform.position, transform.rotation);

            Destroy(_explosion, 2);

        }
    }

   
}
