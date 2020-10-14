using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEngine : MonoBehaviour
{
    public GameObject laserBeam;
    public Transform laserInstantiatePoint;

    
    private GameObject laser;

    private float _time;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
    }

 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _time <= 0)
        {
            laser = Instantiate(laserBeam, laserInstantiatePoint.transform.position, laserInstantiatePoint.transform.rotation);
            SoundManager.PlaySound("LaserShot");
            Destroy(laser, 3);
            _time = 3;
        }
       
    }
    
}
