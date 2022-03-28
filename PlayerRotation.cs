using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Variable donde almacenamos la posición del ratón
    public Vector2 screenPos;

    // Posición del ratón en pantalla convertida a posición en el mundo
    public Vector2 worldPos;

    // Velocidad de rotación
    public float rotationSpeed;

    // Pertenenecia a los componentes del player
    PlayerComponents pC;

    private void Awake()
    {
        // Recuperamos los componentes del jugador.
        pC = GetComponent<PlayerComponents>();
    }

    private void Update()
    {
        RotatePlayer();
    }
    Vector2 GetMouseScreenValues()
    {
        // Este método devuelve la posición del ratón en pantalla
        return pC.c.Player.MousePos.ReadValue<Vector2>();
    }
    void RotatePlayer()
    {
        // Obtenemos la posición que tiene el ratón en la pantalla
        screenPos = GetMouseScreenValues();
        // Convertimos la posición en pantalla del ratón a una posición en el mundo del juego
        worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        // Dirección que hay entre el personaje y el ratón
        Vector2 dir = worldPos - (Vector2)transform.position;

        // Normalizamos la dirección  para que la rotacion se produzca a la misma veloidad independientes
        dir.Normalize();

        // Rotamos al personaje de manera suavizado con Lerpeo
        transform.up = Vector2.Lerp(transform.up, dir, rotationSpeed * Time.deltaTime);
    }
}
