using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulledEnemy : PulledObject
{
    // Direcci�n en la que se desplaza este objeto y asignaeremos desde el script "EnemySpawner"
    public Vector2 dir;
    // Valores m�nimo y m�ximo que podremos aplicar al meteorito.
    public float minSpeed, maxSpeed;

    public override void Initialise()
    {
        // Accedemos a su rigidbody y le aplicamos una velocidad aleatoria.
        GetComponent<Rigidbody2D>().velocity = dir * Random.Range(minSpeed, maxSpeed);
    }
}
