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
        mineCount = 50;
       
        while(mineCount > 0)
        {
            _rndZ = Random.Range(-40, 60);
            _rndX = Random.Range(-50, 40);
            _rndY = Random.Range(20, 30);
            Instantiate(mine, new Vector3(_rndX, _rndY, _rndZ), mine.transform.rotation);
            mineCount--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
