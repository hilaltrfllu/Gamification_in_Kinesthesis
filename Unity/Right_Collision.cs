using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Right_Collision : MonoBehaviour
{
    void OnTriggerEnter()
    {
        KeepScore.currentScore -= 100;
    }
}
