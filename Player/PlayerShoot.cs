using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : PlayerComponents
{
    // Velocidad que asignamos a la bala
    public float bulletSpeed;
    // Refrencia a los puntos donde creamos la bala central, izquierda y derecha.
    public Transform shootingPoint, shootingPointLeft, shootingPointRight;

    private void Start()
    {
        EventsSuscriptions();
    }

    void EventsSuscriptions()
    {
        // Suscripción de eventos.
        c.Player.NormalFire.performed += (x) => NShoot(oP.ExtractObject());

        c.Player.MultipleFire.performed += (x) => MShoot(oP.ExtractObject(),oP.ExtractObject(),oP.ExtractObject());
    }

    void NShoot(GameObject b)
    {
        // Reposicionamos la bala
        b.transform.position = shootingPoint.position;

        // Rotamos la bala
        b.transform.rotation = shootingPoint.rotation;

        // Extraemos su componente PullebBullet y lo alamacenamos en la variable
        PulledBullet pB = b.GetComponent<PulledBullet>();

        // Asignamos la velocidad de la bala.
        pB.speed = bulletSpeed;
        // Inicializamos la bala.
        pB.Initialise();
    }

    void MShoot(GameObject b,GameObject bLeft, GameObject bRight)
    {
        // Reposicionamos las balas.
        b.transform.position = shootingPoint.position;
        bLeft.transform.position = shootingPointLeft.position;
        bRight.transform.position = shootingPointRight.position;

        // Rotamos las balas.
        b.transform.rotation = shootingPoint.rotation;
        bLeft.transform.rotation = shootingPointLeft.rotation;
        bRight.transform.rotation = shootingPointRight.rotation;

        // Extraemos sus componentes PulledBullet y lo almacenamos en variables.
        PulledBullet pB = b.GetComponent<PulledBullet>();
        PulledBullet pBLeft = bLeft.GetComponent<PulledBullet>();
        PulledBullet pBRight = bRight.GetComponent<PulledBullet>();

        // Inicializamos las balas.
        pB.Initialise();
        pBLeft.Initialise();
        pBRight.Initialise();
    }
}
