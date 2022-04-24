using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
	//Declaro la variable de tipo RigidBody que luego asociaremos a nuestro Jugador
	private Rigidbody rb;

	//Declaro la variable p�blica velocidad para poder modificarla desde la Inspector window
	[Range(1, 10)]
	public float velocidad = 5;

	void Start()
	{

		//Capturo el rigidbody del jugador al iniciar el juego
		rb = GetComponent<Rigidbody>();

	}

	void FixedUpdate()
	{

		//Capturo el movimiento en horizontal y vertical de nuestro teclado
		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");

		//Genero el vector de movimiento asociado, teniendo en cuenta la velocidad
		Vector3 movimiento = new Vector3(movimientoH * velocidad, 0.0f, movimientoV * velocidad);

		//Aplico ese movimiento al RigidBody del jugador
		rb.AddForce(movimiento);

	}
	/* A�ade esta l�nea en la declaraci�n de veriables */

	//Declaro la variable p�blica salto para poder modificarla desde la Inspector window
	[Range(1, 10)]
	public float salto = 7;

	
    private void OnTriggerEnter(Collider other)
    {
		//SceneManager.LoadScene("Menu");
	}
}


