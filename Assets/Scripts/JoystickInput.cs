using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : IUserInput
{
    [Header("===== Joystick Settings =====")]
    public string axisX = "axisX";

    public string axisY = "axisY";
    public string axisJright = "axis4";
    public string axisJup = "axis5";

    public string btnA = "btn0";
    public string btnB = "btn1";
    public string btnX = "btn2";
    public string btnY = "btn3";


    // Update is called once per frame
    void Update()
    {
        JUp = -1 * Input.GetAxis(axisJup);
        JRight = Input.GetAxis(axisJright);
        targetDup = Input.GetAxis(axisY);
        targetDright = Input.GetAxis(axisX);

        if (inputEnabled == false)
        {
            targetDup = 0;
            targetDright = 0;
        }

        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);

        Vector2 tempDAxis = SquareToCircle(new Vector2(Dright, Dup));
        float Dright2 = tempDAxis.x;
        float Dup2 = tempDAxis.y;

        Dmag = Mathf.Sqrt((Dup2 * Dup2) + (Dright2 * Dright2));
        Dvec = Dright2 * transform.right + Dup2 * transform.forward;

        run = Input.GetButton(btnA);


        bool newJump = Input.GetButton(btnB);
        jump = newJump;
        if (newJump != lastJump && newJump == true)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        lastJump = newJump;


        bool newAttack = Input.GetButton(btnX);
        attack = newAttack;
        if (newAttack != lastAttack && newAttack == true)
        {
            attack = true;
        }
        else
        {
            attack = false;
        }

        lastAttack = newAttack;
    }
}