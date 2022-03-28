using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Variable donde almacenamos la posici�n del rat�n
    public Vector2 screenPos;

    // Posici�n del rat�n en pantalla convertida a posici�n en el mundo
    public Vector2 worldPos;

    // Velocidad de rotaci�n
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
        // Este m�todo devuelve la posici�n del rat�n en pantalla
        return pC.c.Player.MousePos.ReadValue<Vector2>();
    }
    void RotatePlayer()
    {
        // Obtenemos la posici�n que tiene el rat�n en la pantalla
        screenPos = GetMouseScreenValues();
        // Convertimos la posici�n en pantalla del rat�n a una posici�n en el mundo del juego
        worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        // Direcci�n que hay entre el personaje y el rat�n
        Vector2 dir = worldPos - (Vector2)transform.position;

        // Normalizamos la direcci�n  para que la rotacion se produzca a la misma veloidad independientes
        dir.Normalize();

        // Rotamos al personaje de manera suavizado con Lerpeo
        transform.up = Vector2.Lerp(transform.up, dir, rotationSpeed * Time.deltaTime);
    }
}
