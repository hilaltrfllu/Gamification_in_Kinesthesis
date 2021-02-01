using UnityEngine;
using UnityEngine.UI;

public class Left_Collision : MonoBehaviour
{
    
    void OnTriggerEnter()
    {
        KeepScore.currentScore += 100;
    }




    /*public WaterBoard movingForward;
     public GameObject KeepScore;
     public int score = 0;
     public Text score_text;

     void OnColllisionEnter(UnityEngine.Collision collisionInfo)
     {

         if (collisionInfo.gameObject.tag == "Left_Plane")
         {
             //  KeepScore.Score += 50;
             //  KeepScore.GetComponent<Text>().text = "50";
             score += 50;
             score_text.text = score.ToString();
         }
         if(collisionInfo.gameObject.tag == "Right_Plane")
         {

         }
         if(collisionInfo.gameObject.tag == "Buoy")
         {
             movingForward.enabled = false;
         }

     }*/






}
