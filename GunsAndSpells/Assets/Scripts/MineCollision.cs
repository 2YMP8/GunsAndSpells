using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCollision : MonoBehaviour
{
    #region Varables
    public GameObject explosionPrefab;
    private GameObject _explosion;

    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            _explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

            Destroy(_explosion, 2);

            SoundManager.sndmng.PlayExplotions();

        }
    }   

   
}
