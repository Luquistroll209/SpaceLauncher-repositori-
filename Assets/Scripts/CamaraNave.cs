using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraNave : MonoBehaviour
{
    private float x;
    private float y;
    private Vector3 targetRotation;
    private Vector3 rotateValue;
    public float Sensibilidad;

    public bool CamaraGirar;

    private Camera Camara;

    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Camara = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift))
        {
            if (Camara.fieldOfView < 70)
            {
                Camara.fieldOfView++;
            }
        }
        else
        {
            if (Camara.fieldOfView > 52)
            {
                Camara.fieldOfView--;
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            if (CamaraGirar == true)
            {
                CamaraGirar = false;
            }
            else if (CamaraGirar == false)
            {
                CamaraGirar = true;
            }
        }

        if (CamaraGirar == true)
        {
            x = Input.GetAxis("Mouse X") * Sensibilidad * Time.deltaTime;
            y = Input.GetAxis("Mouse Y") * Sensibilidad * Time.deltaTime;


            xRotation -= y;
            yRotation -= x;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);
            transform.Rotate(Vector3.up * x);
        }
    }
}
