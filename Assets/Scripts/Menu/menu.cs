using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{

    public GameObject play;
    public GameObject world;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        play.SetActive(true);
        world.SetActive(false);
    }

    public void ScenaJuego()
    {
        SceneManager.LoadScene("Alpa Centuria");
    }
    public void Play()
    {
        play.SetActive(false);
        world.SetActive(true);
    }
}
