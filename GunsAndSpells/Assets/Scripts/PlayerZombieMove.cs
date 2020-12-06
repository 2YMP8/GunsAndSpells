using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZombieMove : MonoBehaviour
{

    public GameObject wayPoint;
    private float _timer;


    // Update is called once per frame
    void Update()
    {
        if(_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        if(_timer <= 0)
        {
            UpdatePosition();
            _timer = 0.5f;
        }
    }

  private void  UpdatePosition()
    {
        wayPoint.transform.position = transform.position;
    }
}
