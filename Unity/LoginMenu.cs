using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button loginButton;

    public void CallLogin()
    {
        StartCoroutine(Login());
    }
    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        DBManager.username = nameField.text;

        //   using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form)) {
        using (UnityWebRequest www = UnityWebRequest.Post("http://gaminkin.scienceontheweb.net/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isHttpError || www.isNetworkError)
            {
                Debug.Log("User creation failed. Error #" + www.error);
            }
            else
            {
               // if (DBManager.LoggedIn) { DBManager.username = username; }
                
               // DBManager.username = nameField.GetComponent<InputField>().text;
        //        DBManager.balance = int.Parse(www.method.Split('\n')[0]);
                UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            }
        }
    }
    public void VerifyInputs()
    {
        loginButton.interactable = (nameField.text.Length >= 3) && (passwordField.text.Length >= 3);
    }
}
