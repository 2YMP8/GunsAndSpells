using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    List<string> anmList = new List<string>(new string[] { "Attack1", "Attack2", "Attack3" });
    Animator animator;
    public int comboNum;
    public float reset;
    public float resetTime;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && comboNum < 3)
        {
            animator.SetTrigger(anmList[comboNum]);
            comboNum++;
            reset = 0;
        }
        if (comboNum > 0)
        {
            reset += Time.deltaTime;
            if(reset > resetTime)
            {

            animator.SetTrigger("reset");
            comboNum = 0;
            }

        }
        if (comboNum == 3)
        {
            resetTime = 3;
            comboNum = 0;
        }
        else
        {
            resetTime = 1;
        }
    }
}
