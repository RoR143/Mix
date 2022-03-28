using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    // Puntuaci�n del jugador.
    public int score;
    // Puntuaci�n que el jugador obtiene por estar vivo.
    public int lifeScore;
    // Display en HUD de la puntuaci�n.
    public Text scoreDisplay;

    private void Start()
    {
        // Se inicia la puntuaci�n por vida.
        StartCoroutine(LifeScore());
    }

    public IEnumerator LifeScore()
    {
        while(true)
        {
            // Se a�ade la puntuaci�n establecida y se espera un segundo.
            AddScore(lifeScore);
            yield return new WaitForSeconds(1f);
        }
    }

    public void AddScore(int s)
    {
        // Si se recibe un comando de puntuaci�n, se a�ade a la variable score y se ense�a en el HUD manteniendo formato de 4 ceros.
        score += s;
        scoreDisplay.text = score.ToString("0000");
    }


}
