using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCubo : MonoBehaviour
{
    private bool mover = false;

    //public GameObject cubo;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(cubo);
    }

    // Update is called once per frame
    void Update()
    {
        if (mover)
        {
            transform.position = new Vector3(-2.2f, 2.2f, 5f);
        }
        else if (!mover)
        {
            //transform.Rotate(0, 0, 0);
            transform.position = new Vector3(2.2f, 2.2f, 5f);
        }

    }

    public void CambiarUbicacion()
    {
        mover = !mover;
    }
}
