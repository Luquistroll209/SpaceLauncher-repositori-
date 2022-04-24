using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovimientoNave : MonoBehaviour
{

    [Header("Variables")]

    

    public float Reparacion = 100;
    public float Gasolina = 100;

    private bool RapidezActivada;

    public float VelocidadActual = 20;

    public float VelocidadSubir = 20;

    public float speedGirar;

    public float anguloX;
    public float anguloY;

    public bool jugando;

    public bool TrenDeAterrizaje;

    public bool HaAparcado;

    [Space]

    public GameObject Luz;

    public Camera Camara;

    public Image BarraReparacion;
    public Image BarraGasolina;

    public ParticleSystem EffectoVelocidad;

    public ParticleSystem[] ParticulasMotor;

    public ParticleSystem[] ParticulasMotoresPequeños;

    public CamaraNave CamaraNave;

    public Text GasolinaText;

    public Text VelocidadText;

    public GameObject TreenActivado;

    public Transform Centro;

    public Transform Pantalla1;

    public Image VelocidadImagen;
    

    private void Start()
    {
        TreenActivado.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;

        for (int i = 0; i < ParticulasMotor.Length; i++)
        {
            ParticulasMotor[i].Stop();
        }
        Luz.SetActive(false);

        Reparacion = 100;

        Vector3 posicion = new Vector3(PlayerPrefs.GetFloat("NaveX"), PlayerPrefs.GetFloat("NaveY"), PlayerPrefs.GetFloat("NaveZ"));

        transform.position = posicion;
    }
    


    void Update()
    {


        GasolinaText.text = Mathf.Round(Gasolina).ToString();
        VelocidadText.text = Mathf.Round(VelocidadActual).ToString();
        
        if(VelocidadActual < 0)
        {

            VelocidadImagen.fillAmount = VelocidadActual/-100*2;
            VelocidadImagen.fillOrigin = (int)Image.OriginVertical.Top;

        }
        else
        {
            VelocidadImagen.fillAmount = VelocidadActual / 100;
            VelocidadImagen.fillOrigin = (int)Image.OriginVertical.Bottom;
        }




        if (jugando == true && Gasolina != 0)
        {
            transform.position += transform.forward * VelocidadActual * Time.deltaTime;

            if (VelocidadActual < 0 || VelocidadActual > 0)
            {
                if (Gasolina != 0)
                {
                    Gasolina -= 0.0005f;
                    BarraGasolina.fillAmount = Gasolina / 100;
                }
            }

            // Subir velocidad / Bajar

            if (Input.GetKey(KeyCode.W) && VelocidadActual < 100)
            {
                VelocidadActual += 0.5f;

                if (VelocidadActual > 90)
                {
                    EffectoVelocidad.Play();
                }
            }
            else if (Input.GetKey(KeyCode.S) && VelocidadActual > -50)
            {
                VelocidadActual -= 0.5f;

                if (VelocidadActual < 90)
                {
                    EffectoVelocidad.Stop();
                }
            }

            //if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.LeftShift))
            //{
            //if (RapidezActivada == true)
            // {
            //     ParticulasMotoresPequeños[0].Play();
            //    ParticulasMotoresPequeños[1].Play();
            // }
            // else
            // {
            //  ParticulasMotoresPequeños[0].Stop();
            // ParticulasMotoresPequeños[1].Stop();
            //}
            //}
            //else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.LeftShift))
            //{
            //ParticulasMotoresPequeños[0].Stop();
            //ParticulasMotoresPequeños[1].Stop();
            //}


            if (Input.GetKeyDown(KeyCode.W))
            {
                ParticulasMotor[0].Play();
                ParticulasMotor[1].Play();
                ParticulasMotor[2].Play();
                ParticulasMotor[3].Play();
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                ParticulasMotor[0].Stop();
                ParticulasMotor[1].Stop();
                ParticulasMotor[2].Stop();
                ParticulasMotor[3].Stop();

                ParticulasMotoresPequeños[0].Stop();
                ParticulasMotoresPequeños[1].Stop();
            }


            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, -VelocidadActual * Time.deltaTime);

            }

            if (Input.GetKey(KeyCode.Q))
            {
                transform.position += -transform.up * VelocidadActual * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.E))
            {
                //transform.Rotate(Vector3.up, VelocidadActual * Time.deltaTime);
                transform.position += transform.up * VelocidadActual * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {

                transform.Rotate(Vector3.up, -VelocidadActual * Time.deltaTime);
            }
            ////ir a pantalla 1
            if (Input.GetKey(KeyCode.F1))
            {
                if (Camara.fieldOfView == 52)
                {
                    Camara.transform.rotation = Pantalla1.rotation;
                    Camara.fieldOfView = 27;
                }
                else
                {
                    Camara.transform.rotation = Centro.rotation;
                    Camara.fieldOfView = 52;
                }
            }
            




            ///fin ir a pantalla 1

            if (CamaraNave.CamaraGirar == false)
            {
                anguloX += Input.GetAxis("Mouse X") * speedGirar * -Time.deltaTime;

                anguloY += Input.GetAxis("Mouse Y") * speedGirar * -Time.deltaTime;

                transform.localRotation = Quaternion.Euler(anguloY, -anguloX, transform.rotation.z);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (Luz.activeInHierarchy == true)
                {
                    Luz.SetActive(false);
                }
                else
                {
                    Luz.SetActive(true);
                }  
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                if (TrenDeAterrizaje == true)
                {
                    TrenDeAterrizaje = false;
                    TreenActivado.SetActive(false);

                }
                else
                {
                    
                    TrenDeAterrizaje = true;
                    TreenActivado.SetActive(true);
                }
            }

            BarraReparacion.fillAmount = Reparacion / 100;

        }
        else if (Input.GetKeyDown(KeyCode.R) && HaAparcado == true)
        {
            jugando = true;
            HaAparcado = false;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Planeta"))
        {
            //SceneManager.LoadScene("Menu");
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Suelo") || other.CompareTag("Planeta"))
        {
            if (TrenDeAterrizaje == true)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, -transform.up, out hit))
                {
                    float distancia = Vector3.Distance(transform.position, hit.point);
                    if (distancia < 1)
                    {
                        transform.position += transform.up * VelocidadActual * Time.deltaTime;
                        HaAparcado = true;
                        jugando = false;
                    }
                }
            }
            else
            {
                Debug.Log("Luquiiiiiissssss activa el tren de aterisaje con la L que no es tan dificil e");
            }
        }
    }

}
