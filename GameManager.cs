using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton.
    public static GameManager instance;
    // Referencia al menú post-muerte.
    public GameObject deathMenu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void DeathMenu()
    {
        // Si se recibe el comando, se activa el menú.
        deathMenu.SetActive(true);
    }
    public void SceneReload()
    {
        // Si se pulsa el botón de reinicio del menú, se reinicia la escena.
        SceneManager.LoadScene(0);
    }
}
