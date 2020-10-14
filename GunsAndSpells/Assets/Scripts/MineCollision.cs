using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCollision : MonoBehaviour
{
    #region Varables
    public GameObject explosionPrefab;
    private GameObject _explosion;

    public GameObject mine;

    private float time;

    #endregion

    private void Update()
    {
        time -= Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            _explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

            Destroy(_explosion, 2);

            SoundManager.sndmng.PlayExplotions();
            time = 3;
            Destroy(gameObject);
            BarsEngine.lifeCount -= 25;
            SoundManager.sndmng.PlayPainHits();

            GameObject.Find("InstantiateEngine").GetComponent<InstantiateEngine>().mineCount += 1;


            if (time <= 0)
            {
               GameObject.Find("InstantiateEngine").GetComponent<InstantiateEngine>().mineCount = 1;
                time = 3;
            }

        }
    }   
   
}
