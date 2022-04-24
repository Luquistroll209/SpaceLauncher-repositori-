using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coche : MonoBehaviour
{
    public float speed = 20;

    public float maxspeed = 100;

    public float minspeed = 5;

    public float rootSpeed1 = 50;

    public float rootSpeed2 = 50;

    public float speedGirar;

    public float anguloX;
    public float anguloY;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;

        }
        else
        {

        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, -speed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * -speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {

            transform.Rotate(Vector3.up, -speed * Time.deltaTime);
        }

        anguloX += Input.GetAxis("Mouse X") * speedGirar * -Time.deltaTime;

        anguloY += Input.GetAxis("Mouse Y") * speedGirar * -Time.deltaTime;

        transform.localRotation = Quaternion.Euler(anguloY, -anguloX, transform.rotation.z);

    }
}
