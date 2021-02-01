using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameOver : MonoBehaviour
{
    //public GameObject LR_BalanceBox;
    //public GameObject FB_BalanceBox;
    public float balance;
    public string username;
    public int score;

    private void OnTriggerEnter()
    {
        balance = DBManager.dbBalance();
        score = KeepScore.currentScore;
        username = DBManager.username;

        StartCoroutine(UpdateDB());
        
        IEnumerator UpdateDB()
        {

            WWWForm form = new WWWForm();
            form.AddField("username", username);
            form.AddField("balance", balance.ToString());
            form.AddField("score", score.ToString());

            using (UnityWebRequest www = UnityWebRequest.Post("http://gaminkin.scienceontheweb.net/updateBalance.php", form))
            {

                yield return www.SendWebRequest(); //Pauses the execution of coroutine

                if (www.isHttpError || www.isNetworkError)
                {
                    Debug.Log("User data update failed. Error #" + www.error);
                }
                else
                {
                    Debug.Log("User data updated successfully");
                    //          UnityEngine.SceneManagement.SceneManager.LoadScene(1);

                }
            }

        }
    }
}
