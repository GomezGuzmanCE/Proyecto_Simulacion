using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public PlayerCtrl player;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Puntos: "+player.puntos.ToString();
    }
}
