using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEngineSpace : MonoBehaviour
{
   
    public GameObject aidKit;
    public int aidCount;

    private float _rndX;
    private float _rndZ;
    private float _rndY;


    // Start is called before the first frame update
    void Start()
    {
   
        aidCount = 500;

        while (aidCount > 0)
        {
            _rndZ = Random.Range(-100, 100);
            _rndX = Random.Range(-100, 100);
            _rndY = Random.Range(10, 20);
            Instantiate(aidKit, new Vector3(_rndX, _rndY, _rndZ), aidKit.transform.rotation);
            aidCount--;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (aidCount == 1)
        {
            Instantiate(aidKit, new Vector3(_rndX, _rndY, _rndZ), aidKit.transform.rotation);
            aidCount = 0;
        }

    }

}
