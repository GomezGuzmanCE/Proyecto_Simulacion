using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subMenuScript : MonoBehaviour
{
    public SceneCtrl sceneCtrl;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            sceneCtrl.ChangeScene("Menu");
        }

    }
}
