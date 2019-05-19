using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuCtrl : MonoBehaviour
{

    public int distanceOfRaycast;

    private RaycastHit _hit;
    private CharacterController controller;

    public SceneCtrl sceneCtrl;

    public string BotonNombre = "";

    public AudioClip click;
    public GameObject musica;
    AudioSource fuenteAudio;

    public float speedH = 18.0f;
    //public float speedV = 15.0f;
    private float yaw = 0.0f;
    //private float pinch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        fuenteAudio = musica.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            fuenteAudio.clip = click;
            fuenteAudio.Play();


            if (BotonNombre == "Inicio")
            {
                sceneCtrl.ChangeScene("01");
            }
            else if (BotonNombre == "Controles")
            {
                sceneCtrl.ChangeScene("Controles");
            }
            else if (BotonNombre == "Salir")
            {
                sceneCtrl.CerrarApp();
            }
            else if (BotonNombre == "Creditos")
            {
                sceneCtrl.ChangeScene("Creditos");
            }
        
        }
        if (Input.GetButtonDown("Fire4"))
        {
            yaw += speedH;
            transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        }
        if (Input.GetButtonDown("Fire5"))
        {
            yaw -= speedH;
            transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        }
        // }
    }

    public void NombreDeBoton(string n)
    {
        BotonNombre = n;
    }
}
