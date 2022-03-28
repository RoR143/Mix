using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerComponents))] //Hacemos que la clase PlayerMovement dependa de la clase PlayerComponents. De esta forma, siempre ir�n juntas.
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    // Control de aceleraci�n de la velocidad.
    public float acceleration;

    // Velocidad m�xima del jugador.
    public float maxSpeed;

    // Variables para controlar la velocidad de desplazamiento.
    public float xSpeed, ySpeed;

    // Vector que recuperamos del sistema de inputs mediante la pulsaci�n de WASD.
    public Vector2 movement;

    // Pertenenecia a los componentes del player.
    PlayerComponents pC;

    private void Awake()
    {
        //Recuperamos los componentes del jugador.
        pC = GetComponent<PlayerComponents>();
    }
    private void Update()
    {
        GetMovementValues();
    }

    private void FixedUpdate()
    {
        Movement(movement.x, movement.y);
    }

    void GetMovementValues() //Obtenemos los valores del movimiento del input
    {
        movement = pC.c.Player.Movement.ReadValue<Vector2>();
    }

    void Movement(float x, float y)
    {
        // Modificamos la velocidad de X y Y de manera progresiva dependiendo de la aceleraci�n
        xSpeed += acceleration * x * Time.deltaTime;
        ySpeed += acceleration * y * Time.deltaTime;

        // Reducimos las velocidades si no se est�n pulsando las teclas
        if (x == 0)
        {
            xSpeed = Mathf.MoveTowards(xSpeed, 0f, acceleration * Time.deltaTime);
        }
        if (y == 0)
        {
            ySpeed = Mathf.MoveTowards(ySpeed, 0f, acceleration * Time.deltaTime);
        }

        // Limitaci�n de velocidad
        xSpeed = Mathf.Clamp(xSpeed, -maxSpeed, maxSpeed);
        ySpeed = Mathf.Clamp(ySpeed, -maxSpeed, maxSpeed);

        // Asignamos un vector de movimiento
        Vector2 motion = new Vector2(xSpeed, ySpeed);

        // Clampeamos la magnitud del vector para que no supere la velocidad m�xima diagonal.
        motion = Vector2.ClampMagnitude(motion, maxSpeed);

        // Aplicamos el desplazamiento directamente sobre el velocity del rigidbody.
        pC.rB.velocity = motion;
    }
}
