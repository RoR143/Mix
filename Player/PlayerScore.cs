using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    // Puntuación del jugador.
    public int score;
    // Puntuación que el jugador obtiene por estar vivo.
    public int lifeScore;
    // Display en HUD de la puntuación.
    public Text scoreDisplay;

    private void Start()
    {
        // Se inicia la puntuación por vida.
        StartCoroutine(LifeScore());
    }

    public IEnumerator LifeScore()
    {
        while(true)
        {
            // Se añade la puntuación establecida y se espera un segundo.
            AddScore(lifeScore);
            yield return new WaitForSeconds(1f);
        }
    }

    public void AddScore(int s)
    {
        // Si se recibe un comando de puntuación, se añade a la variable score y se enseña en el HUD manteniendo formato de 4 ceros.
        score += s;
        scoreDisplay.text = score.ToString("0000");
    }


}
