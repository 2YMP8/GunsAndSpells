using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEngine : MonoBehaviour
{
    public GameObject mine;
    public int mineCount;

    public GameObject aidKit;
    public int aidCount;

    private float _rndX;
    private float _rndZ;
    private float _rndY;


    // Start is called before the first frame update
    void Start()
    {
        mineCount = 50;
       
        while(mineCount > 0)
        {
            _rndZ = Random.Range(-40, 60);
            _rndX = Random.Range(-50, 40);
            _rndY = Random.Range(20, 30);
            Instantiate(mine, new Vector3(_rndX, _rndY, _rndZ), mine.transform.rotation);
            mineCount--;
        }

        aidCount = 30;

        while (aidCount > 0)
        {
            _rndZ = Random.Range(-40, 60);
            _rndX = Random.Range(-50, 40);
            _rndY = Random.Range(20, 30);
            Instantiate(aidKit, new Vector3(_rndX, _rndY, _rndZ), aidKit.transform.rotation);
            aidCount--;
        }

    }

    // Update is called once per frame
    void Update()
    {
     
        if (mineCount == 1)
        {
            Instantiate(mine, new Vector3(_rndX, _rndY, _rndZ), mine.transform.rotation);
            mineCount = 0;
        }
        else if ( aidCount == 1)
        {
            Instantiate(aidKit, new Vector3(_rndX, _rndY, _rndZ), aidKit.transform.rotation);
            aidCount = 0;
        }

    }
}
