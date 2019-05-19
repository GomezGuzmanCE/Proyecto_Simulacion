using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    public PlayerCtrl player;
    public Text timeText;

    // Update is called once per frame
    void Update()
    {
        timeText.text = "Tiempo: " + player.tiempoText.ToString();
    }
}
