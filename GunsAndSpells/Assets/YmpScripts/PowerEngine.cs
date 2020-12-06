using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerEngine : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed;

    public void SaveDirection(Vector3 dir)
    {
        _direction = dir.normalized;
    }

    private void Start()
    {
        _speed = 10;
    }

    void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
