using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    // Velocidad que asignamos a la bala.
    public float bulletSpeed;
    // Tiempo entre proyectiles.
    public float bulletDelay;
    // Refrencia a los puntos donde creamos la bala.
    public Transform shootingPoint;

    private void OnEnable()
    {
        // Cuando el enemigo spawnea, se inicia fuego continuo.
        StartCoroutine(ContinousFire());
    }
    private void OnDisable()
    {
        // Cuando desespawnea, se desactiva.
        StopAllCoroutines();
    }
    public IEnumerator ContinousFire()
    {
        while(true)
        {
            // Se disparan balas con un delay establecido en el inspector.
            NShootCont(GetComponent<ObjectPool>().ExtractObject());
            yield return new WaitForSeconds(bulletDelay);
        }
    }
    void NShootCont(GameObject b)
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
}
