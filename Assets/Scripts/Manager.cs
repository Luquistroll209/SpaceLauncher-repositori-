using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Nave;
    public MovimientoNave MovimientoNave;

    public GameObject Menu;

    public GameObject GuardadoText;

    private void Awake()
    {
        Menu.SetActive(false);
        GuardadoText.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Nave == null)
        {
            Nave = GameObject.FindGameObjectWithTag("Player");
        }
        if (MovimientoNave == null)
        {
            MovimientoNave = Nave.GetComponent<MovimientoNave>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Menu.activeInHierarchy == true)
            {
                Menu.SetActive(false);
                MovimientoNave.jugando = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (Menu.activeInHierarchy == false)
            {
                Menu.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
            }

        }
    }

    public void Resumen()
    {
        Menu.SetActive(false);
        MovimientoNave.jugando = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    /* (Esto para el futuro)
     public void guardar()
    {
        PlayerPrefs.SetFloat("NaveX", transform.position.x);
        PlayerPrefs.SetFloat("NaveY", transform.position.y);
        PlayerPrefs.SetFloat("NaveZ", transform.position.z);
        
        guardadoText.SetActive(true);
        StartCoroutine("guardadoquit");
     }

    IEnumerator guardadoquit()
    {
        yield return new WaitForSeconds(2);
        guardadoText.SetActive(false);
    }
*/

}
