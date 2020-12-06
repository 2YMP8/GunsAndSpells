using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarEngine : MonoBehaviour
{
    #region Varables
    public Camera mainCam;

    private Vector3 _sides, _forward;
    private Vector3 _facingDirection;
    private float _inputSides, _inputForward;
    private float _inputMouseX, _inputMouseY;
    private float _speed, _maxJampDelay;
    private int _jump;
    private float _lastTimeJumped;

    private Rigidbody rb;
    private Animator _anim;

    private bool _isGrounded;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _checkSphere;

    private int _onClicks;
    private float _lastTimeClicked, _maxComboDelay;
    private bool _fightAttak;

    public Transform powerUpPoint;

    private bool _fierBallAttack;
    public GameObject fierBallPrefab;
    private GameObject _fierBall;

    private bool _iceLanceAttack;
    public GameObject iceLancePrefab;
    private GameObject _iceLance;

    private string[] _powerUps = new string[3];
    public static bool powerUpsFull;

    public float _platformBoardForce;

    private bool fireBar;
    private bool iceBar;
    private float maxFire = 100;
    private float maxIce = 100;
    private float maxAmmo = 30;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

        _speed = 0;
        _jump = 0;
        _lastTimeJumped = 0;
        _groundCheckRadius = 0.5f;
        _onClicks = 0;
        _lastTimeClicked = 0;
        _maxComboDelay = 1.5f;
        _maxJampDelay = 0.8f;
        _platformBoardForce = 20000;
       

        _fierBallAttack = false;
        _iceLanceAttack = false;
        _fightAttak = true;

        _powerUps[0] = "FightMode";
        powerUpsFull = false;
    }


    void Update()
    {  
        InputControl();
        if (_inputSides != 0 || _inputForward != 0)
            MovePlayer(mainCam.transform.right, mainCam.transform.forward);
        AnimationControl();
    }

    private void LateUpdate()
    {
        CheckIsGrounded();
    }

    private void InputControl()
    {
        _inputMouseX = Input.GetAxis("Mouse X");
        _inputMouseY = Input.GetAxis("Mouse Y");

        _inputSides = Input.GetAxis("Horizontal");
        _inputForward = Input.GetAxis("Vertical");

        //movment
        if (_inputSides != 0 || _inputForward != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _speed = 1;
            }
            else
            {
                _speed = 0.5f;
            }
        }
        else
        {
            _speed = 0;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _jump < 2)
        {
             _lastTimeJumped = Time.time;
            _jump++;
        }
        if (Time.time - _lastTimeJumped > _maxJampDelay)
        {
            _jump = 0;
        }

        //Attack
        if (Input.GetMouseButtonDown(0))
        {
            _lastTimeClicked = Time.time;
            if (_fightAttak)
            {
                _maxComboDelay = 1.5f;
                _onClicks++;
                _onClicks = Mathf.Clamp(_onClicks, 0, 3);

            }
            else
            {
                _onClicks = 1;
                _maxComboDelay = 0.1f;
            }


           /* if (_onClicks == 1)
            {
                SoundManager.PlaySound("Hit1");
                StartCoroutine(TimerHit1());

            }
            else if (_onClicks == 2)
            {
               StartCoroutine(TimerHit2());
            }
            else if (_onClicks == 3)
            {
                StartCoroutine(TimerHit3());

            }*/
        }
        if (Time.time - _lastTimeClicked > _maxComboDelay)
        {
            _onClicks = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))//Fight combo
        {
            ModeSwitch(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))//Scond powerup
        {
            ModeSwitch(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))//Therd poerup 
        {
            ModeSwitch(2);
        }

    }

    private void MovePlayer(Vector3 sidesRefrence, Vector3 forwardRefrence)
    {
        _sides = sidesRefrence * _inputSides;
        _forward = forwardRefrence * _inputForward;

        _facingDirection = _sides + _forward;
        _facingDirection.y = 0;
        _facingDirection.Normalize();

        Quaternion rotationTarget = Quaternion.LookRotation(_facingDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationTarget, Time.deltaTime * 2.8f);
    }

    private void AnimationControl()
    {
        //_anim.SetFloat("Speed", _speed);
        _anim.SetFloat("Speed", _speed,0.2f,Time.deltaTime);
        _anim.SetInteger("Jump", _jump);
        _anim.SetBool("IsGrounded", _isGrounded);
        _anim.SetInteger("Attack", _onClicks);
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("KB_p_OneTwo") || !_fightAttak)
        {
            _anim.SetBool("OneTwo", false);
        }
        else
        {
            _anim.SetBool("OneTwo", true);
        }
        _anim.SetBool("FierBallAttack", _fierBallAttack);
        _anim.SetBool("IceLanceAttack", _iceLanceAttack); 
    }

    private void CheckIsGrounded()
    {
        _isGrounded = Physics.CheckSphere(_checkSphere.position, _groundCheckRadius, _groundMask);

        if (!_isGrounded)
        {
            transform.Translate(0, 0, Mathf.Abs(_inputForward) * 2 * Time.deltaTime);
        }
    }

    //function calld by animation
    private void MyAddForce()
    {
        rb.AddForce(transform.up * 1000);
        //rb.AddForce(transform.forward * 500);
    }

    private void FierBallFunc()
    {
        _fierBall = Instantiate(fierBallPrefab, powerUpPoint.position, Quaternion.identity);
        _fierBall.GetComponent<Rigidbody>().AddForce(transform.forward * 300,ForceMode.Acceleration);
        BarsEngine.fireCount--;
        Destroy(_fierBall.gameObject,2);
    }

    private void IceLanceFunc()
    {
        _iceLance = Instantiate(iceLancePrefab, powerUpPoint.position, transform.rotation);
        // _iceLance.GetComponent<Rigidbody>().AddForce(transform.forward * 500, ForceMode.Acceleration);
        BarsEngine.iceCount--;
        Destroy(_iceLance.gameObject, 2);
    }
    //til here.


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FireMode"))
        {
            CheckSpaceInPowerUps("FireMode");
            BarsEngine.fireCount = maxFire;
        }
        else if (other.CompareTag("IceMode"))
        {
            CheckSpaceInPowerUps("IceMode");
            BarsEngine.iceCount = maxIce;

        }
        else if (other.CompareTag("WeaponMode"))
        {
            BarsEngine.ammoCount = maxAmmo;

        }
        else if (other.CompareTag("Trap"))
        {
            SoundManager.sndmng.PlayPainHits();
            BarsEngine.lifeCount -= 10;
        }
    }

    private void CheckSpaceInPowerUps(string power)
    {
        if (_powerUps[1] == null)
        {
            _powerUps[1] = power;
        }
        else if(_powerUps[2] == null)
        {
            _powerUps[2] = power;
            powerUpsFull = true;
        }
    }

    private void ModeSwitch(int i)
    {
        switch (_powerUps[i])
        {
            case "FightMode":
                _fightAttak = true;
                _fierBallAttack = false;
                _iceLanceAttack = false;
                break;

            case "FireMode":
                _fightAttak = false;
                _fierBallAttack = true;
                _iceLanceAttack = false;
            
                break;

            case "IceMode":
                _fightAttak = false;
                _fierBallAttack = false;
                _iceLanceAttack = true;
                            
                break;

            default:
                break;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Ground")
    //    {
    //        _jump = 0;
    //        print("ground");
    //    }
    //}

    #region TimerHit
    /*    IEnumerator TimerHit1()
        {
            yield return new WaitForSeconds(0.8f);
            SoundManager.PlaySound("Hit1");

        }
        IEnumerator TimerHit2()
        {
            yield return new WaitForSeconds(0.2f);
            SoundManager.PlaySound("Hit2");

        }
        IEnumerator TimerHit3()
        {
            yield return new WaitForSeconds(0.2f);
            SoundManager.PlaySound("Hit3");

        }*/
    #endregion

          
}
