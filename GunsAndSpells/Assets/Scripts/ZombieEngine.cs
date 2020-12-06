using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEngine : MonoBehaviour
{
    private float _speed = 1f;
    private GameObject _wayPoint;
    private Vector3 wayPointPos;
    private float _timer;
    private bool _isDead;

    private Animator _anim;
    //public Transform playerLookAt;

    // Start is called before the first frame update
    void Start()
    {
        _wayPoint = GameObject.Find("ZombieWayPoint");
        _anim = GetComponent<Animator>();
        _isDead = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!_isDead)
        {
            //WalkTowardsThePlayer
            wayPointPos = new Vector3(_wayPoint.transform.position.x, _wayPoint.transform.position.y, _wayPoint.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, _speed * Time.deltaTime);

            //LookAtThePlayer
            transform.LookAt(wayPointPos);
        }
     


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_isDead)
        {
            _anim.SetBool("IsAttack", true);
            BarsEngine.lifeCount -= 5;
            SoundManager.sndmng.PlayPainHits();
            
        }

        if (collision.gameObject.CompareTag("FireBall"))
        {
            _anim.SetTrigger("IsDead");
            Destroy(this.gameObject, 10);
            Destroy(collision.gameObject);
            _isDead = true;
        }
    
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _timer -= Time.deltaTime;
            if(_timer <= 0)
            {
                _anim.SetBool("IsAttack", true);
                StartCoroutine(EveryOneSec());
                _timer = 1;
            }
           
        }
         
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _anim.SetBool("IsAttack", false);
        }
    }

    IEnumerator EveryOneSec()
    {
        yield return new WaitForSeconds(2);
        BarsEngine.lifeCount -= 5;
        SoundManager.sndmng.PlayPainHits();
    }
}
