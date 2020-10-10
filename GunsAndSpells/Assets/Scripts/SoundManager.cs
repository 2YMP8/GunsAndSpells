using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Varables
    public static AudioClip[] ExplotionsSound;
    private int _rndExplotionSound;

    public static AudioClip hit1Sound, hit2Sound, hit3Sound;

    public static AudioSource audioSrc;
    public static SoundManager sndmng;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        sndmng = this;
        audioSrc = GetComponent<AudioSource>();

        ExplotionsSound = Resources.LoadAll<AudioClip>("Sounds/Explostions");
        hit1Sound = Resources.Load<AudioClip>("Sounds/Hit1");
        hit2Sound = Resources.Load<AudioClip>("Sounds/Hit2");
        hit3Sound = Resources.Load<AudioClip>("Sounds/Hit3");

    }

    //onShotHits
    public static void PlaySound(string clip)
    {
        switch (clip)

        {
            case "Hit1":
                audioSrc.PlayOneShot(hit1Sound);
                break;

            case "Hit2":
                audioSrc.PlayOneShot(hit2Sound);
                break;

            case "Hit3":
                audioSrc.PlayOneShot(hit3Sound);
                break;


        }
    }

    //ExpotionsArray
        public void PlayExplotions()
        {
           _rndExplotionSound = Random.Range(0, 3);
          audioSrc.PlayOneShot(ExplotionsSound[_rndExplotionSound]);
        }
    }
   