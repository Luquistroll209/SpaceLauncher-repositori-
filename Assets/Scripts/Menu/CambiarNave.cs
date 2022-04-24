using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarNave : MonoBehaviour
{
    public MeshFilter Objeto;

    public string NaveActual;

    public Mesh Nave1;
    public Mesh Nave2;
    public Mesh Nave3;

    private void Start()
    {
        if (PlayerPrefs.HasKey("NaveActual"))
        {
            NaveActual = PlayerPrefs.GetString("NaveActual");
        }
        else
        {
            NaveActual = "Nave1";
        }
    }

    public void Cambiar1()
    {
        if (NaveActual == "Nave1")
        {
            Objeto.mesh = Nave2;
            NaveActual = "Nave2";
        }
        else if (NaveActual == "Nave2")
        {
            Objeto.mesh = Nave3;
            NaveActual = "Nave3";
        }
        else if (NaveActual == "Nave3")
        {
            Objeto.mesh = Nave1;
            NaveActual = "Nave1";
        }
        PlayerPrefs.SetString("NaveActual", NaveActual);
    }

    public void Cambiar2()
    {
        if (NaveActual == "Nave1")
        {
            Objeto.mesh = Nave3;
            NaveActual = "Nave3";
        }
        else if (NaveActual == "Nave2")
        {
            Objeto.mesh = Nave1;
            NaveActual = "Nave1";
        }
        else if (NaveActual == "Nave3")
        {
            Objeto.mesh = Nave2;
            NaveActual = "Nave2";
        }
        PlayerPrefs.SetString("NaveActual", NaveActual);
    }
}
