using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarsEngine : MonoBehaviour
{
    public Image lifeBar;
    public Image iceBar;
    public Image fireBar;
    public Image ammoBar;

    public Text lifeText;
    public Text iceText;
    public Text fireText;
    public Text ammoText;

    public float maxLife = 100;
    public static float lifeCount;

    public float maxFire = 10;
    public static float fireCount;

    public float maxIce = 10;
    public static float iceCount;

    public float maxAmmo = 30;
    public static float ammoCount;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        lifeCount = maxLife;
        fireCount = 0;
        iceCount = 0;
        ammoCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lifeBar.fillAmount = lifeCount / maxLife;
        fireBar.fillAmount = fireCount / maxFire;
        iceBar.fillAmount = iceCount / maxIce;
        ammoBar.fillAmount = ammoCount / maxAmmo;

        lifeText.text = lifeCount + "/100".ToString();
        iceText.text = iceCount + "/100".ToString();
        fireText.text = fireCount + "/100".ToString();
        ammoText.text = ammoCount + "/30".ToString();

        if (lifeCount > 100)
        {
            lifeCount = 100;
        }

    }


}
