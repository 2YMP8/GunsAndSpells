using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossTarget : MonoBehaviour
{
    private Camera mainCamera;

    private Ray _ray;
    private RaycastHit _hitInfo;

    void Start()
    {
        mainCamera = Camera.main;
    }

    
    void Update()
    {
        _ray.origin = mainCamera.transform.position;
        _ray.direction = mainCamera.transform.forward;
        Physics.Raycast(_ray, out _hitInfo);
        transform.position = _hitInfo.point;
    }
}
