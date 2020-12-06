using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEngineZombie : MonoBehaviour
{
    public GameObject mine;
    public int mineCount;

    public GameObject aidKit;
    public int aidCount;

    public GameObject zombie;
    public int zombieCount;
    public float zombieTimer;
    public Transform instantiatePoint1, instantiatePoint2, instantiatePoint3;
   private int _instantiateNum;

    private float _rndX;
    private float _rndZ;
    private float _rndY;


    // Start is called before the first frame update
    void Start()
    {
        mineCount = 200;

        while (mineCount > 0)
        {
            
            Instantiate(mine, new Vector3(_rndX, _rndY, _rndZ), mine.transform.rotation);
            mineCount--;
        }

        aidCount = 100;

        while (aidCount > 0)
        {
            _rndZ = Random.Range(1, 1000);
            _rndX = Random.Range(1, 1000);
            _rndY = Random.Range(90, 100);
            Instantiate(aidKit, new Vector3(_rndX, _rndY, _rndZ), aidKit.transform.rotation);
            aidCount--;
        }

        zombieTimer = Random.Range(2, 5);
        zombieCount = 0;
        _instantiateNum = 1;

    }

    // Update is called once per frame
    void Update()
    {

        if (mineCount == 1)
        {
            Instantiate(mine, new Vector3(_rndX, _rndY, _rndZ), mine.transform.rotation);
            mineCount = 0;
        }
        else if (aidCount == 1)
        {
            Instantiate(aidKit, new Vector3(_rndX, _rndY, _rndZ), aidKit.transform.rotation);
            aidCount = 0;
        }



        zombieTimer -= Time.deltaTime;
        while (zombieCount <= 200 && zombieTimer <= 0)
        {
            if(_instantiateNum == 1)
            {
                Instantiate(zombie, instantiatePoint1.position, zombie.transform.rotation); Instantiate(zombie, instantiatePoint1.position, zombie.transform.rotation);
                _instantiateNum = 2;
            }

            else if (_instantiateNum == 2)
            {
                Instantiate(zombie, instantiatePoint2.position, zombie.transform.rotation); Instantiate(zombie, instantiatePoint1.position, zombie.transform.rotation);
                _instantiateNum = 3;
            }

            else if (_instantiateNum == 3)
            {
                Instantiate(zombie, instantiatePoint3.position, zombie.transform.rotation); Instantiate(zombie, instantiatePoint1.position, zombie.transform.rotation);
                _instantiateNum = 1;
            }

            zombieTimer = (Random.Range(2,5));
            zombieCount++;
            
        }
    }
}
