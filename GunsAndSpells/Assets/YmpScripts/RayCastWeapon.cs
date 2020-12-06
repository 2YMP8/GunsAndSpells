using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    public bool isFiring;

    public ParticleSystem[] muzzuleFlash;
    public ParticleSystem hitEffect, bloodEffect;

    public TrailRenderer trailEffect;


    public Transform raycastOrigin;
    public Transform crossTraget;

    private Ray _ray;
    private RaycastHit _hitInfo;

    private void Start()
    {
        isFiring = false;
    }

    public void StartFiring()
    {
        isFiring = true;
        foreach (var partical in muzzuleFlash)
        {
            partical.Emit(1);
        }

        _ray.origin = raycastOrigin.position;
        _ray.direction = crossTraget.position - raycastOrigin.position;

        var _traile = Instantiate(trailEffect, _ray.origin, Quaternion.identity);
        _traile.AddPosition(_ray.origin);

        if (Physics.Raycast(_ray, out _hitInfo))
        {
            //Debug.DrawLine(_ray.origin, _hitInfo.point, Color.red, 1.0f);
            if (_hitInfo.transform.CompareTag("Player"))
            {
                bloodEffect.transform.position = _hitInfo.point;
                bloodEffect.transform.forward = _hitInfo.normal;
                bloodEffect.Emit(1);
            }
            else
            {
                hitEffect.transform.position = _hitInfo.point;
                hitEffect.transform.forward = _hitInfo.normal;
                hitEffect.Emit(1);
            }

            _traile.transform.position = _hitInfo.point;
        }
    }

    public void StopFiring()
    {
        isFiring = false;
    }
}
