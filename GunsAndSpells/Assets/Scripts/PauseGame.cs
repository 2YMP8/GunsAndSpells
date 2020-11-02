using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public GameObject GeneralSettings_Canvas;

    private int EscapeNum;

    // Start is called before the first frame update
    void Start()
    {
        EscapeNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && EscapeNum == 0)
        {
            GeneralSettings_Canvas.SetActive(true);
            EscapeNum = 1;
            Time.timeScale = 0;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && EscapeNum == 1)
        {
            GeneralSettings_Canvas.SetActive(false);
            EscapeNum = 0;
            Time.timeScale = 1;
        }
    }
}
