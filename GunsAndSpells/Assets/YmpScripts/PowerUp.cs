using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject smokeEffectPrefab;
    public Transform inPosition;
    private GameObject _smokeEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        if (!AvatarEngine.powerUpsFull)
        {
            Destroy(gameObject);
            _smokeEffect = Instantiate(smokeEffectPrefab, inPosition.position, transform.rotation);
            Destroy(_smokeEffect.gameObject, 1.5f);
        }
    }
}
