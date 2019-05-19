using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 12f;
    int distanceOfRaycast = 4;
    //float rotationSpeed = 100.0f;
    char ban = ' ';

    private float gravity = 10f;
    private RaycastHit _hit;
    private CharacterController controller;

    public GameObject cuboV;
    public GameObject cuboA;
    public GameObject cuboR;
    public GameObject manos;
    public GameObject AreaS;
    public GameObject Zona0;
    public GameObject canvas2;
    public GameObject canvas3;

    public bool manosOcupadas = false;

    Collider CuboV_col;
    Collider CuboA_col;
    Collider CuboR_col;
   
    public int puntos = 0;
    public int objetos = 0;

    public AudioClip click;
    public AudioClip arroja;
    public AudioClip mal;
    public AudioClip bien;
    public AudioClip agarra;
    public AudioClip win;
    public AudioClip pause;

    AudioSource audioGeneral;

    public GameObject sonido;
    AudioSource audios;

    float startTime;
    public string tiempoText = "0:0.00";

    public bool play = true;
    public SceneCtrl sceneCtrl;

    int cantidadGanar = 10;

    public float speedH = 18.0f;
    //public float speedV = 15.0f;
    private float yaw = 0.0f;
    //private float pinch = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        CuboV_col = cuboV.GetComponent<BoxCollider>();
        CuboA_col = cuboA.GetComponent<BoxCollider>();
        CuboR_col = cuboR.GetComponent<BoxCollider>();

        controller = GetComponent<CharacterController>();

        audios = sonido.GetComponent<AudioSource>();
        audioGeneral = GetComponent<AudioSource>();

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (objetos == cantidadGanar) play = false;

        if (play)
        {
            canvas2.SetActive(false);
            canvas3.SetActive(false);
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            PlayerMovement();

            Tiempo();

            if (Physics.Raycast(ray, out _hit, distanceOfRaycast))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    if (!manosOcupadas)
                    {
                        if (_hit.transform.CompareTag("CuboVerde")) AgarrarObjeto('v');
                        else if (_hit.transform.CompareTag("CuboAzul")) AgarrarObjeto('a');
                        else if (_hit.transform.CompareTag("CuboRojo")) AgarrarObjeto('r');
                    }
                }
                else if (Input.GetButtonDown("Fire3"))
                {
                    if (manosOcupadas)
                    {
                        DepositarBote();
                    }
                }
            }

            if (Input.GetButtonDown("Fire3"))
            {
                if (manosOcupadas)
                {
                    EfectoSonido("soltar");
                    if (ban == 'v') SoltarObjeto('v', false);
                    else if (ban == 'a') SoltarObjeto('a', false);
                    else if (ban == 'r') SoltarObjeto('r', false);
                    puntos--;
                }
            }
        }
        else
        {
            //objetos
            if (objetos >= cantidadGanar) canvas3.SetActive(true);
            if (Input.GetButtonDown("Fire2")) sceneCtrl.ChangeScene("Menu");
        }
        if(Input.GetButtonDown("Jump"))
        {
            if (objetos >= cantidadGanar)
            {
                sceneCtrl.ChangeScene("01");
            }
            else
            {
                play = !play;
                EfectoSonido("pausa");
                canvas2.SetActive(true);
            }
            
        }
    }

    //#############################################################################
    //#############################################################################
    //#############################################################################


    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(hor, 0, ver);
        Vector3 vel = dir * speed;
        vel = Camera.main.transform.TransformDirection(vel);
        vel.y -= gravity;
        controller.Move(vel * Time.deltaTime);

        //yaw += speedH * Input.GetAxis("Mouse X");
        if(Input.GetButtonDown("Fire4"))
        {
            yaw += speedH;
            transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        }
        if (Input.GetButtonDown("Fire5"))
        {
            yaw -= speedH;
            transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        }
        //yaw += speedH * Input.GetButtonDown("Fire3");
        //pinch -= speedV * Input.GetAxis("Mouse Y");


    }

    public void SoltarObjeto(char c, bool enBote)
    {
        if(c=='v')
        {
            cuboV.transform.SetParent(AreaS.transform);
            cuboV.transform.localPosition = AreaS.transform.localPosition;
            cuboV.transform.SetParent(null);
            cuboV.transform.Rotate(0f, 0f, 0f);
            cuboV.transform.rotation = Quaternion.identity;
            cuboV.transform.position = new Vector3(cuboV.transform.position.x, 1f, cuboV.transform.position.z);
            cuboV.transform.localScale = new Vector3(1f, 1f, 1f);
            CuboV_col.isTrigger = false;
            manosOcupadas = false;
            ban = ' ';

            if (enBote)
            {
                cuboV.transform.position = Zona0.transform.localPosition;
                AparacerObjetos();
            }
        }
        else if (c == 'a')
        {
            cuboA.transform.SetParent(AreaS.transform);
            cuboA.transform.localPosition = AreaS.transform.localPosition;
            cuboA.transform.SetParent(null);
            cuboA.transform.Rotate(0f, 0f, 0f);
            cuboA.transform.rotation = Quaternion.identity;
            cuboA.transform.position = new Vector3(cuboA.transform.position.x, 1f, cuboA.transform.position.z);
            cuboA.transform.localScale = new Vector3(1f, 1f, 1f);
            manosOcupadas = false;
            CuboA_col.isTrigger = false;
            ban = ' ';

            if (enBote)
            {
                cuboA.transform.position = Zona0.transform.localPosition;
                AparacerObjetos();
            }
        }
        else if (c == 'r')
        {
            cuboR.transform.SetParent(AreaS.transform);
            cuboR.transform.localPosition = AreaS.transform.localPosition;
            cuboR.transform.SetParent(null);
            cuboR.transform.Rotate(0f, 0f, 0f);
            cuboR.transform.rotation = Quaternion.identity;
            cuboR.transform.position = new Vector3(cuboR.transform.position.x, 1f, cuboR.transform.position.z);           
            cuboR.transform.localScale = new Vector3(1f, 1f, 1f);
            manosOcupadas = false;
            CuboR_col.isTrigger = false;
            ban = ' ';

            if (enBote)
            {
                cuboR.transform.position = Zona0.transform.localPosition;
                AparacerObjetos();
            }

        }

        
    }

    public void AgarrarObjeto(char c)
    {
        EfectoSonido("agarrar");

        if (c == 'v')
        {
            //cuboV.GetComponent<RotateCube>().ChangeSpin;
            cuboV.transform.SetParent(manos.transform);
            cuboV.transform.localPosition = manos.transform.localPosition;
            cuboV.transform.localScale = new Vector3(.3f, .3f, .3f);
            CuboV_col.isTrigger = true;
            manosOcupadas = true;
            
            ban = 'v';
        }
        else if (c == 'a')
        {
            cuboA.transform.SetParent(manos.transform);
            cuboA.transform.localPosition = manos.transform.localPosition;
            cuboA.transform.localScale = new Vector3(.3f, .3f, .3f);          
            manosOcupadas = true;
            CuboA_col.isTrigger = true;
            ban = 'a';
        }
        else if (c == 'r')
        {
            cuboR.transform.SetParent(manos.transform);
            cuboR.transform.localPosition = manos.transform.localPosition;
            cuboR.transform.localScale = new Vector3(.3f, .3f, .3f);         
            manosOcupadas = true;
            CuboR_col.isTrigger = true;
            ban = 'r';
        }

        puntos++;
    }

    void AparacerObjetos()
    { 
        int n = Random.Range(1,4);
        int rnd = Random.Range(1, 3);
        float x = 0f;
        float z = 0f;

        if(rnd==1)
        {
            x = Random.Range(-43, 43);
            z = Random.Range(-10, 10);
        }
        else if(rnd==2)
        {
            x = Random.Range(-10, 10);
            z = Random.Range(-43, 43);
        }

        if (n == 1) cuboA.transform.position = new Vector3(x, 1f, z);
        else if (n == 2) cuboV.transform.position = new Vector3(x, 1f, z);
        else if (n == 3) cuboR.transform.position = new Vector3(x, 1f, z);
    }

    void DepositarBote()
    {
        if (_hit.transform.CompareTag("BoteV"))
        {
            if (ban == 'v') { puntos++; EfectoSonido("bien"); }
            else { puntos--; EfectoSonido("mal"); }

            SoltarObjeto(ban, true);
        }
        else if (_hit.transform.CompareTag("BoteA"))
        {
            if (ban == 'a') { puntos++; EfectoSonido("bien"); }
            else { puntos--; EfectoSonido("mal"); }

            SoltarObjeto(ban, true);
        }
        else if (_hit.transform.CompareTag("BoteR"))
        {
            if (ban == 'r') { puntos++; EfectoSonido("bien"); }
            else { puntos--; EfectoSonido("mal"); }

            SoltarObjeto(ban, true);
        }

        objetos++;
        if (objetos == cantidadGanar)
        {
            audioGeneral.mute = true;
            EfectoSonido("ganar");
        }
    }

    void EfectoSonido(string s)
    {
        if (s == "agarrar") audios.clip = agarra;
        else if (s == "soltar") audios.clip = arroja;
        else if (s == "bien") audios.clip = bien;
        else if (s == "mal") audios.clip = mal;
        else if (s == "click") audios.clip = click;
        else if (s == "ganar") audios.clip = win;
        else if (s == "pausa") audios.clip = pause;

        audios.Play();
    }

    void Tiempo()
    {
        float t = Time.time - startTime;
        string min = ((int)t / 60).ToString();
        string sec = (t % 60).ToString("f2");

        tiempoText = min + ":" + sec;
    }
}
