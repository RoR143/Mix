using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulledBullet : PulledObject
{
    //Velocidad de desplazamiento que se asigna desde el script PlayShoot
    public float speed;
    public override void Initialise()
    {
        // Aplicamos velocidad sobre la bala.
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}
