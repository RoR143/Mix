using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnResetSpawner : EnemySpawner
{
    //Cantidad min y max de objetos que se crean
    public int minAmount, maxAmount;

    [ContextMenu("LoopSpawn")]
    public void LoopSpawn()
    {
        // Obtenemos un valor aleatorio que será la cantidad de meteoritos que se crearán.
        int r = Random.Range(minAmount, maxAmount + 1);

        // Con un bucle for, creamos tantos objetos como haya salido en el random.
        for (int i = 0; i < r; i++)
        {
            // Creamos el objeto.
            Spawn();
        }
    }
}
