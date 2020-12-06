using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class AvatarEngine : MonoBehaviour
{
    #region Varables
    private Camera _mainCam;
    [SerializeField] private Transform _lookAt;

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

    private bool _iceLanceAttack;

    private GameObject _powerEffect;

    private string _powerName;
    private string[] _powerUps = new string[3];
    public static bool powerUpsFull;

    public float _platformBoardForce;

    private bool fireBar;
    private bool iceBar;
    private float maxFire = 100;
    private float maxIce = 100;
    private float maxAmmo = 30;

    private bool _weaponIn, _weaponOut;
    [SerializeField] private bool _weaponMode;
    public GameObject weapon;

    [SerializeField] private GameObject _aimCamera;
    private int _priority;
    private float _cameraX;
    private bool _aimMode;

    [SerializeField] private GameObject _fightRing;
    [SerializeField] private Transform _ringPoint;
    private GameObject _ringEffect;

    private RayCastWeapon _weaponRay;
    private RigBuilder _rigBuilder;
    [SerializeField] private Transform _crossTarget;

    private PowerUpsDataBase _powerData;

    public GameObject imgPower1, imgPower2,bar1,bar2;
    private int _witchBar;
    #endregion

    void Start()
    {
        _mainCam = Camera.main;

        rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _weaponRay = GetComponentInChildren<RayCastWeapon>();
        _rigBuilder = GetComponent<RigBuilder>();

        _powerData = GameObject.Find("PowerUpsDataBase").GetComponent<PowerUpsDataBase>();

        _speed = 0;
        _jump = 0;
        _lastTimeJumped = 0;
        _groundCheckRadius = 0.5f;
        _onClicks = 0;
        _lastTimeClicked = 0;
        _maxComboDelay = 1.5f;
        _maxJampDelay = 0.8f;
        _platformBoardForce = 20000;
       
        _maxJampDelay = 1f;

        _powerUps[0] = "FightMode";
        _fightAttak = true;
        _fierBallAttack = false;
        _iceLanceAttack = false;
        _weaponMode = false;

        powerUpsFull = false;

        _priority = 0;
        _aimMode = false;
    }


    void Update()
    {
        InputControl();
        AnimationControl();
        //MoveAimMode();
    }

    private void FixedUpdate()
    {
        //if (!_aimMode)
        //{
        //    MovePlayer(_mainCam.transform.right, _mainCam.transform.forward);
        //}
        //else
        //{
        //    MovePlayer(transform.right, transform.forward);
        //}

        MovePlayer();
    }

    private void LateUpdate()
    {
        CheckIsGrounded();
    }

    private void InputControl()
    {
        _inputMouseX = Input.GetAxis("Mouse X");
        // _inputMouseY = Input.GetAxis("Mouse Y");
        _inputMouseY = _mainCam.transform.rotation.eulerAngles.y;

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
            if (!_weaponMode)
            {
                _maxComboDelay = 1.5f;
                _onClicks++;
                _onClicks = Mathf.Clamp(_onClicks, 0, 3);

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
            }
            else//Shooting
            {
                _weaponRay.StartFiring();
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

        if (Input.GetMouseButtonDown(1))
        {
            switch (_priority)
            {
                case 0:
                    _aimCamera.GetComponent<CinemachineFreeLook>().Priority = 20;
                    _priority = 20;
                    //_aimPoint.SetActive(true);
                    _aimMode = true;
                    break;

                case 20:
                    _aimCamera.GetComponent<CinemachineFreeLook>().Priority = 0 ;
                    _priority = 0;
                    //_aimPoint.SetActive(false);
                    _aimMode = false;
                    break;
            }
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

    //private void MovePlayer(Vector3 sidesRefrence, Vector3 forwardRefrence)
    //{
    //    _sides = sidesRefrence * _inputSides;
    //    _forward = forwardRefrence * _inputForward;

    //    _facingDirection = _sides + _forward;
    //    _facingDirection.y = 0;
    //    _facingDirection.Normalize();


    //    Quaternion rotationTarget = Quaternion.LookRotation(_facingDirection);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, rotationTarget, Time.deltaTime * 2.8f);

    //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, _inputMouseY, 0), 15 * Time.fixedDeltaTime);
    
    //}

    private void MovePlayer()
    {

        _facingDirection = _crossTarget.position - powerUpPoint.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, _inputMouseY, 0), 15 * Time.fixedDeltaTime);

    }

    private void MoveAimMode()
    {
        transform.Rotate(0, _inputMouseX * 50 * Time.deltaTime, 0);

        //Look Up & Down
        _cameraX = _cameraX - (_inputMouseY * 50 / 2 * Time.deltaTime);
        _cameraX = Mathf.Clamp(_cameraX, -30, 30);
        _aimCamera.transform.localRotation = Quaternion.Euler(_cameraX, 0, 0);
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
 
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("EquipRifle"))
        {
            _weaponOut = false;
        }
        _anim.SetBool("WeaponOut", _weaponOut);

        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("HolsterRifle"))
        {
            _weaponIn = false;
        }
        _anim.SetBool("WeaponIn", _weaponIn);

        //Aim walk
        _anim.SetFloat("InputForward", _inputForward);
        _anim.SetFloat("InputSide", _inputSides);
        _anim.SetBool("AimMode", _aimMode);
    }

    private void CheckIsGrounded()
    {
        _isGrounded = Physics.CheckSphere(_checkSphere.position, _groundCheckRadius, _groundMask);

        if (!_isGrounded)
        {
            transform.Translate(_inputSides * 3 * Time.deltaTime, 0, Mathf.Abs(_inputForward) * 5 * Time.deltaTime);
        }
    }

    //function calld by animation
    private void MyAddForce()
    {
        rb.AddForce(transform.up * 1000);
        //rb.AddForce(transform.forward * 500);
        switch (_jump)
        {
            case 1:
                rb.AddForce(transform.up * 250);
                break;

            case 2:
                rb.AddForce(transform.up * 500);
                break;
        }
    }

    private void ShootPower()
    {
        _fierBall = Instantiate(fierBallPrefab, powerUpPoint.position, Quaternion.identity);
        _fierBall.GetComponent<Rigidbody>().AddForce(transform.forward * 300,ForceMode.Acceleration);
        BarsEngine.fireCount--;
        Destroy(_fierBall.gameObject,2);
        for (int j = 0; j <= _powerData.spells.Length; j++)
        {
            if (_powerData.spells[j].Name == _powerName)
            {
                _powerEffect = Instantiate(_powerData.spells[j].power, powerUpPoint.position, transform.rotation);
                _powerEffect.transform.LookAt(_facingDirection);
                _powerEffect.GetComponent<PowerEngine>().SaveDirection(_facingDirection);
                Destroy(_powerEffect.gameObject, 2);
                break;
            }
        }
        if(_witchBar == 1)
        {
            bar1.GetComponent<Image>().fillAmount -= 0.2f;
        }
        else if(_witchBar == 2)
        {
            bar2.GetComponent<Image>().fillAmount -= 0.2f;
        }

    }

    //private void FierBallFunc()
    //{
    //    _fierBall = Instantiate(fierBallPrefab, powerUpPoint.position, Quaternion.identity);
    //    _fierBall.GetComponent<PowerEngine>().SaveDirection(_facingDirection);
    //    Destroy(_fierBall.gameObject,2);
    //}

    //private void IceLanceFunc()
    //{
    //    _iceLance = Instantiate(iceLancePrefab, powerUpPoint.position, transform.rotation);
    //    _iceLance.GetComponent<PowerEngine>().SaveDirection(_facingDirection);
    //    Destroy(_iceLance.gameObject, 2);
    //}

    private void EquipRifle()
    {
        weapon.SetActive(true);
    }
    private void HolsterRifle()
    {
       // _iceLance = Instantiate(iceLancePrefab, powerUpPoint.position, transform.rotation);
        // _iceLance.GetComponent<Rigidbody>().AddForce(transform.forward * 500, ForceMode.Acceleration);
        BarsEngine.iceCount--;
        Destroy(_iceLance.gameObject, 2);
        weapon.SetActive(false);
    }
    //til here.


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FireBall"))
        {
            CheckSpaceInPowerUps("FireBall");
        }
        else if (other.CompareTag("IceLance"))
        {
            CheckSpaceInPowerUps("FireMode");
            BarsEngine.fireCount = maxFire;
            CheckSpaceInPowerUps("IceLance");
        }
        else if (other.CompareTag("WeaponMode"))
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
            CheckSpaceInPowerUps("WeaponMode");
        }
    }

    private void CheckSpaceInPowerUps(string power)
    {
        if (_powerUps[1] == null)
        {
            _powerUps[1] = power;
            if (power != "WeaponMode")
            {
                for (int j = 0; j <= _powerData.spells.Length; j++)
                {
                    if (_powerData.spells[j].Name == power)
                    {
                        imgPower1.GetComponent<Image>().sprite = _powerData.spells[j].icon;
                        imgPower1.SetActive(true);
                        bar1.SetActive(true);
                        break;
                    }
                }
            }
            else
            {
                imgPower1.GetComponent<Image>().sprite = _powerData.weapons[0].icon;
                imgPower1.SetActive(true);
                bar1.SetActive(true);
            }
        }
        else if(_powerUps[2] == null)
        {
            _powerUps[2] = power;
            powerUpsFull = true;
            if (power != "WeaponMode")
            {
                for (int j = 0; j <= _powerData.spells.Length; j++)
                {
                    if (_powerData.spells[j].Name == power)
                    {
                        imgPower2.GetComponent<Image>().sprite = _powerData.spells[j].icon;
                        imgPower2.SetActive(true);
                        bar2.SetActive(true);
                        break;
                    }
                }
            }
            else
            {
                imgPower2.GetComponent<Image>().sprite = _powerData.weapons[0].icon;
                imgPower2.SetActive(true);
                bar2.SetActive(true);
            }
        }
    }

    private void ModeSwitch(int i)
    {
        _witchBar = i;
        if (_powerUps[i] == "WeaponMode")
        {
            _rigBuilder.enabled = true;
            for (int j = 0; j <= _powerData.weapons.Length; j++)
            {
                if (_powerData.weapons[j].Name == "M16A4")
                {
                    //_powerName = _powerData.weapons[j].Name;
                    _ringEffect = Instantiate(_powerData.weapons[j].ringEffect, _ringPoint.position, Quaternion.identity);
                    Destroy(_ringEffect, 2);
                    break;
                }
            }
        }
        else if(_powerUps[i] != "FightMode")
        {
            _rigBuilder.enabled = false;
            for (int j = 0; j <= _powerData.spells.Length; j++)
            {
                if (_powerData.spells[j].Name == _powerUps[i])
                {
                    _powerName = _powerData.spells[j].Name;
                    _ringEffect = Instantiate(_powerData.spells[j].ringEffect, _ringPoint.position, Quaternion.identity);
                    Destroy(_ringEffect, 2);
                    break;
                }
            }
        }


        switch (_powerUps[i])
        {
            case "FightMode":
                _fightAttak = true;
                _fierBallAttack = false;
                _iceLanceAttack = false;
                if (_weaponMode)
                {
                    _weaponIn = true;
                    _weaponMode = false;
                }
                _ringEffect = Instantiate(_fightRing, _ringPoint.position, Quaternion.identity);
                Destroy(_ringEffect, 2);
                break;

            case "FireBall":
                _fightAttak = false;
                _fierBallAttack = true;
                _iceLanceAttack = false;
                if (_weaponMode)
                {
                    _weaponIn = true;
                    _weaponMode = false;
                }
                break;

            case "IceLance":
                _fightAttak = false;
                _fierBallAttack = false;
                _iceLanceAttack = true;
                if (_weaponMode)
                {
                    _weaponIn = true;
                    _weaponMode = false;
                }
                break;

            case "WeaponMode":
                _fightAttak = false;
                _fierBallAttack = false;
                _iceLanceAttack = false;
                _weaponOut = true;
                _weaponMode = true;
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
