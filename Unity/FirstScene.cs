using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstScene : MonoBehaviour
{
   public void GoToLoginMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitLoginMenu()
    {
        Application.Quit();
    }
}
