using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepScore : MonoBehaviour
{
    public GameObject ScoreBox;
    public static int currentScore = 0;
    public int internalScore = 0;

    // Update is called once per frame
    void Update()
    {
        internalScore = currentScore;
        ScoreBox.GetComponent<Text>().text = "" + internalScore;
    }

   /* void OnGUI()
    {
        //  GUI.Box(new Rect(100, 100, 100, 100), Score.ToString());

      //  score_txt = GetComponent<TextMesh>();
        score_txt.text = Score.ToString();

    }*/
}
