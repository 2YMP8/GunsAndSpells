using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKitEngine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && BarsEngine.lifeCount != 100)
        {
            SoundManager.PlaySound("HealthUp");
            Destroy(gameObject);
            BarsEngine.lifeCount += 25;

            GameObject.Find("InstantiateEngine").GetComponent<InstantiateEngine>().aidCount += 1;

        }
    }
}
