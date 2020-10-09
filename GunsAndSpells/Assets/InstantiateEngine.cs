using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEngine : MonoBehaviour
{
    public GameObject mine;
    private float _rndX;
    private float _rndZ;
    private float _rndY;
    private int mineCount;

    // Start is called before the first frame update
    void Start()
    {
        mineCount = 10;
       
        while(mineCount > 0)
        {
            _rndZ = Random.Range(-100, 15);
            _rndX = Random.Range(-100, 100);
            _rndY = Random.Range(10, 30);
            Instantiate(mine, new Vector3(_rndX, _rndY, _rndZ), mine.transform.rotation);
            mineCount--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
