﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceUpdate : MonoBehaviour
{
    public Text x;  //GetBalanceBoard
    public Text y;
    public Text z;
    public Text w;

    public Text a;  //GetRawBalanceBoard
    public Text b;
    public Text c;
    public Text d;

    public Text e;  //GetCenterOfBalance
    public Text f;

    public Text h; //GetTotalWeight

    public Text balance; //Data that will be updated

    // Start is called before the first frame update
    void Start()
    {
        x.text = "0";
    }

    // Update is called once per frame
    void FixedUpdate()
    {

 /*     Returns the weight in kilograms on each of the four sensors in the balance board. 
		The x-value is the top right sensor.
		The y-value is the top left sensor.
		The z-value is the bottom right sensor.
		The w-value is the bottom left sensor.  */

        x.text = Wii.GetBalanceBoard(0).x.ToString();
        y.text = Wii.GetBalanceBoard(0).y.ToString();
        z.text = Wii.GetBalanceBoard(0).z.ToString();
        w.text = Wii.GetBalanceBoard(0).w.ToString();

 /*     Returns the raw values generated by the four sensors in the balance board. 
		The x-value is the top right sensor.
		The y-value is the top left sensor.
		The z-value is the bottom right sensor.
		The w-value is the bottom left sensor.  */

        a.text = Wii.GetRawBalanceBoard(0).x.ToString();
        b.text = Wii.GetRawBalanceBoard(0).y.ToString();
        c.text = Wii.GetRawBalanceBoard(0).z.ToString();
        d.text = Wii.GetRawBalanceBoard(0).w.ToString();

/*    Returns a Vector 2 representing the distribution of weight on the balance board.
*     The x-value represents the difference in weight between the right and left sides.
*     The y-value represents the difference in weight between the front and back sides. 
      If there is no weight or the weight is evenly distributed, Vector2.zero is returned. */

        e.text = Wii.GetCenterOfBalance(0).x.ToString();
        f.text = Wii.GetCenterOfBalance(0).y.ToString();

        DBManager.rl_balance = Wii.GetCenterOfBalance(0).x;
        DBManager.fb_balance = Wii.GetCenterOfBalance(0).y;

        balance.text = ((Wii.GetCenterOfBalance(0).x + Wii.GetCenterOfBalance(0).y) / 2).ToString();

        //     Returns the total weight on the balance board in kilograms.

        h.text = Wii.GetTotalWeight(0).ToString();

    }
}
