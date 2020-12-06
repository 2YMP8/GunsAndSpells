using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapChooseButtons : MonoBehaviour
{
public void MapButtons(string Button)
    {
        if(Button == "Space")
        {
            SceneManager.LoadScene("Space");
        }

        if(Button == "Village")
        {
            SceneManager.LoadScene("Village");
        }

        if(Button == "ZombieCity")
        {
            SceneManager.LoadScene("ZombieCity");
        }
    }
}
