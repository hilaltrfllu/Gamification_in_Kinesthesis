using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UserMenu : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Button signupButton;
    
    public void CallSignup()
    {
        StartCoroutine(Signup());
    }
    IEnumerator Signup()
    {
        
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);


        //using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/signup.php", form))
        using (UnityWebRequest www = UnityWebRequest.Post("http://gaminkin.scienceontheweb.net/signup.php", form))
        {

            yield return www.SendWebRequest(); //Pauses the execution of coroutine

            if (www.isHttpError || www.isNetworkError)
            {
                Debug.Log("User creation failed. Error #" + www.error);
            }
            else
            {
                Debug.Log("User created successfully");
                //          UnityEngine.SceneManagement.SceneManager.LoadScene(1);

            }
        }   
        
    }
     public void VerifyInputs()
     {
         signupButton.interactable = (nameField.text.Length >= 3) && (passwordField.text.Length >= 3);
     }


}
