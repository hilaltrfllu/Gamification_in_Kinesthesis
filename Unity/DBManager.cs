using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class DBManager
{
    public static string username;
    public static int score;
    public static float rl_balance;
    public static float fb_balance;
    public static float db_balance;

    public static bool LoggedIn { get { return username != null; } }

    public static float dbBalance()
    {
        db_balance = ((rl_balance + fb_balance) / 2);
        return db_balance;
    }
    
    public static void LogOut()
    {
        username = null;
    }
}
