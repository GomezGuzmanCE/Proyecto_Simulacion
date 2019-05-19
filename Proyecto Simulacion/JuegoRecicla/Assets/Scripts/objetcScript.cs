using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objetcScript : MonoBehaviour
{
    public PlayerCtrl player;
    public Text objectText;

    // Update is called once per frame
    void Update()
    {
        objectText.text = "Objetos: " + player.objetos.ToString();
    }
}
