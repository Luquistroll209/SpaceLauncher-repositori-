using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explocion : MonoBehaviour
{
    public bool Asteroide = true;
    public ParticleSystem Explocion1;
    public ParticleSystem Explocion2;

    public void Update()
    {
        transform.Rotate(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explocion1.transform.parent = null;
        Explocion2.transform.parent = null;
        Explocion1.Play();
        Explocion2.Play();
        GameObject.Find("Jupiter 2").GetComponent<MovimientoNave>().Reparacion -= 10;
        Destroy(gameObject);
    }
}
