using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserName : MonoBehaviour
{
    public Text UsernameText;
    public string u_username;

    private void Start()
    {
        u_username = DBManager.username;
        UsernameText.text = u_username;
    }
}
