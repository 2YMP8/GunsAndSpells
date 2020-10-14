using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEngine : MonoBehaviour
{
    public float lineShot;
    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        lineShot = 10000;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.AddForce(transform.forward * lineShot * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BarsEngine.lifeCount -= 5;
            SoundManager.sndmng.PlayPainHits();
            Destroy(gameObject);

        }
        else
        {
            Destroy(gameObject, 0.5f);
        }
    }    

}
