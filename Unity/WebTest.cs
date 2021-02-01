using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class WebTest : MonoBehaviour
{
    private void Start()
    {
        //StartCoroutine(GetRequest("http://localhost/sqlconnect/signup.php"));
        StartCoroutine(GetRequest("http://gaminkin.scienceontheweb.net/signup.php"));
    }
    IEnumerator GetRequest(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        string[] webResults = url.Split('\t') ;

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log("Error: " + request.error);
        }
        else
        {
            Debug.Log("\nReceived: " + request.downloadHandler.text);
        }
    }
}
