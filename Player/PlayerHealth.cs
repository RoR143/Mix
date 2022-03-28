using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Salud del jugador.
    public int health;
    // Display en corazones de la salud.
    public Text hearts;

    public void GetDamage(int d)
    {
        // Se le quita a la salud la cantidad de daño recibida.
        health -= d;

        // Se retiran los corazones correspondientes. Si se llega a 0, se mata al jugador.
        if (health == 2)
        {
            hearts.text = "❤️❤️";
        }
        else if (health == 1)
        {
            hearts.text = "❤️";
        }
        else if (health <= 0)
        {
            hearts.text = null;
            // Desactivamos el jugador.
            gameObject.SetActive(false);
            // Activamos el menú tras muerte.
            GameManager.instance.DeathMenu();
        }
    }

}
