using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public float spinForce = 60f;
    public bool isSpinning = false;
    

    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(0, spinForce * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSpinning)
        {
            transform.Rotate(0, spinForce * Time.deltaTime, 0);
        }
        else if (isSpinning)
        {
            transform.Rotate(0, 0, 0);
        }
        
    }

    public void ChangeSpin()
    {
        isSpinning = !isSpinning;
    }
    
}
