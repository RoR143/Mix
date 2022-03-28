using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpawner : EnemySpawner
{
    //Tiempo minimo y maximo que puede tardar en crear un objeto
    public float minSpawnDelay, maxSpawnDelay;

    protected override void Start()
    {
        //Mantenemos la base del script EnemySpawner
        base.Start();
        //Damos inicio a la corrutina
        StartCoroutine(TimeSpawn());
    }
    IEnumerator TimeSpawn()
    {
        //Esta corrutina se ejecuta de manera infinita
        while (true)
        {
            //Aplicamos una espera aleatoria
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            //Y cuando finalice crearemos un objeto
            Spawn();
        }
    }

}
