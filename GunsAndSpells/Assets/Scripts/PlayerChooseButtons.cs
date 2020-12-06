using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerChooseButtons : MonoBehaviour
{
    int playerNum;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;
    public GameObject player6;
    public GameObject player7;
    public GameObject player8;
    public GameObject player9;
    public GameObject player10;
    public GameObject player11;
    public GameObject player12;
    public GameObject player13;
    public GameObject player14;
    public GameObject player15;

    // Start is called before the first frame update
    void Start()
    {
        playerNum = 1;
        player1.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerNum--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerNum++;

        }

        if (playerNum == 1)
        {
            player1.SetActive(true);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
            player6.SetActive(false);
            player7.SetActive(false);
            player8.SetActive(false);
            player9.SetActive(false);
            player10.SetActive(false);
            player11.SetActive(false);
            player12.SetActive(false);
            player13.SetActive(false);
            player14.SetActive(false);
            player15.SetActive(false);

        }

        else if (playerNum == 2)
        {
            player1.SetActive(false);
            player2.SetActive(true);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
            player6.SetActive(false);
            player7.SetActive(false);
            player8.SetActive(false);
            player9.SetActive(false);
            player10.SetActive(false);
            player11.SetActive(false);
            player12.SetActive(false);
            player13.SetActive(false);
            player14.SetActive(false);
            player15.SetActive(false);

        }

        if (playerNum == 3)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(true);
            player4.SetActive(false);
            player5.SetActive(false);
            player6.SetActive(false);
            player7.SetActive(false);
            player8.SetActive(false);
            player9.SetActive(false);
            player10.SetActive(false);
            player11.SetActive(false);
            player12.SetActive(false);
            player13.SetActive(false);
            player14.SetActive(false);
            player15.SetActive(false);

        }

        if (playerNum == 4)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(true);
            player5.SetActive(false);
            player6.SetActive(false);
            player7.SetActive(false);
            player8.SetActive(false);
            player9.SetActive(false);
            player10.SetActive(false);
            player11.SetActive(false);
            player12.SetActive(false);
            player13.SetActive(false);
            player14.SetActive(false);
            player15.SetActive(false);

        }

        if (playerNum == 5)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(true);
            player6.SetActive(false);
            player7.SetActive(false);
            player8.SetActive(false);
            player9.SetActive(false);
            player10.SetActive(false);
            player11.SetActive(false);
            player12.SetActive(false);
            player13.SetActive(false);
            player14.SetActive(false);
            player15.SetActive(false);

        }

        if (playerNum == 6)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
            player6.SetActive(true);
            player7.SetActive(false);
            player8.SetActive(false);
            player9.SetActive(false);
            player10.SetActive(false);
            player11.SetActive(false);
            player12.SetActive(false);
            player13.SetActive(false);
            player14.SetActive(false);
            player15.SetActive(false);

        }

        if (playerNum == 7)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
            player6.SetActive(false);
            player7.SetActive(true);
            player8.SetActive(false);
            player9.SetActive(false);
            player10.SetActive(false);
            player11.SetActive(false);
            player12.SetActive(false);
            player13.SetActive(false);
            player14.SetActive(false);
            player15.SetActive(false);

        }

        if (playerNum == 8)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
            player6.SetActive(false);
            player7.SetActive(false);
            player8.SetActive(true);
            player9.SetActive(false);
            player10.SetActive(false);
            player11.SetActive(false);
            player12.SetActive(false);
            player13.SetActive(false);
            player14.SetActive(false);
            player15.SetActive(false);

        }

        if (playerNum == 9)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
            player6.SetActive(false);
            player7.SetActive(false);
            player8.SetActive(false);
            player9.SetActive(true);
            player10.SetActive(false);
            player11.SetActive(false);
            player12.SetActive(false);
            player13.SetActive(false);
            player14.SetActive(false);
            player15.SetActive(false);

        }

        if (playerNum == 10)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
            player6.SetActive(false);
            player7.SetActive(false);
            player8.SetActive(false);
            player9.SetActive(false);
            player10.SetActive(true);
            player11.SetActive(false);
            player12.SetActive(false);
            player13.SetActive(false);
            player14.SetActive(false);
            player15.SetActive(false);

        }

        if (playerNum == 11)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
            player6.SetActive(false);
            player7.SetActive(false);
            player8.SetActive(false);
            player9.SetActive(false);
            player10.SetActive(false);
            player11.SetActive(true);
            player12.SetActive(false);
            player13.SetActive(false);
            player14.SetActive(false);
            player15.SetActive(false);

        }

        if (playerNum == 12)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
            player6.SetActive(false);
            player7.SetActive(false);
            player8.SetActive(false);
            player9.SetActive(false);
            player10.SetActive(false);
            player11.SetActive(false);
            player12.SetActive(true);
            player13.SetActive(false);
            player14.SetActive(false);
            player15.SetActive(false);

        }

        if (playerNum == 13)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
            player6.SetActive(false);
            player7.SetActive(false);
            player8.SetActive(false);
            player9.SetActive(false);
            player10.SetActive(false);
            player11.SetActive(false);
            player12.SetActive(false);
            player13.SetActive(true);
            player14.SetActive(false);
            player15.SetActive(false);

        }

        if (playerNum == 14)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
            player6.SetActive(false);
            player7.SetActive(false);
            player8.SetActive(false);
            player9.SetActive(false);
            player10.SetActive(false);
            player11.SetActive(false);
            player12.SetActive(false);
            player13.SetActive(false);
            player14.SetActive(true);
            player15.SetActive(false);

        }

        if (playerNum == 15)
        {

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            player5.SetActive(false);
            player6.SetActive(false);
            player7.SetActive(false);
            player8.SetActive(false);
            player9.SetActive(false);
            player10.SetActive(false);
            player11.SetActive(false);
            player12.SetActive(false);
            player13.SetActive(false);
            player14.SetActive(false);
            player15.SetActive(true);

        }

        if (playerNum > 15)
        {
            playerNum = 1;
        }

        else if (playerNum < 1)
        {
            playerNum = 15;
        }

    }

    public void Buttons(string button)
    {
        if (button == "Left")
        {
            playerNum -= 1;

        }

        if (button == "Right")
        {
            playerNum += 1;
        }

        if (button == "MainMenu")
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (button == "PlayerChoose")
        {
            PlayerPrefs.SetInt("selectedCharacter", playerNum);
            SceneManager.LoadScene("MapChoose");
        }
    }
}
   


