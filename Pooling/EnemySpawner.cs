using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpawnValues
{
    // Punto de referencia donde se realiza el spawn del objeto
    public Transform basePos;
    // Variación que aplicamos sobre la posición del objeto
    public Vector2 offset;
    // Posición base hacia donde desplazamos el objeto
    public Vector2 baseDir;
    // Variación que aplicamos sobre la dirección base
    public Vector2 dirVariation;
    // Si true se muestran las referencias visuales de este punto de spawn
    public bool showVisualRef;
}
public class EnemySpawner : MonoBehaviour
{
    //Array con los puntos donde podemos crear objetos y la configuración de cada uno
    public SpawnValues[] spawnAreas;

    //Referencias
    ObjectPool oP;

    protected virtual void Start()
    {
        //Recuperamos el componente
        oP = GetComponent<ObjectPool>();
    }

    public void Spawn()
    {
        //Extraemos un punto de spawn aleatorio de los que hay configurados en el array
        SpawnValues sV = spawnAreas[Random.Range(0, spawnAreas.Length)];
        //Extraemos un meteorito de la pool y asignamos a una variable su componente PulledEnemy.
        PulledEnemy pE = oP.ExtractObject().GetComponent<PulledEnemy>();

        //Definimos el transform que usaremos para posicionar el objeto
        Transform tRef = sV.basePos;

        //Creamos un vector con valores aleatorios para aplicar sobre el posicionamiento del personaje
        Vector2 spawnOffset = new Vector2(
            Random.Range(-sV.offset.x, sV.offset.x),
            Random.Range(-sV.offset.y, sV.offset.y));

        // Posicionamos el objeto en el punto de spawn que hemos definido
        pE.transform.position = (Vector2)tRef.position + spawnOffset;

        //Variable donde almacenaremos la dirección a la que se mueve el objeto
        Vector2 d = new Vector2();


        d = sV.baseDir + new Vector2(
            Random.Range(-sV.dirVariation.x, sV.dirVariation.x),
            Random.Range(-sV.dirVariation.y, sV.dirVariation.y)
                );

        //Normalizamos la dirección obtenida
        d.Normalize();

        //Asignamos la direccion al objeto creado
        pE.dir = d;

        //Inicializamos 
        pE.Initialise();
    }
    void VisualRefs()
    {
        //Recorremos los puntos de spawn para comprobar si hay que mostrar o no sus referencias visuales.
        foreach (SpawnValues sV in spawnAreas)
        {
            //Solo se muestran las referencias visuales  de los puntos que nos interesan
            if (sV.showVisualRef)
            {
                if (sV.basePos)
                {
                    //Si tenemos posición base, dibujamos un par de líneas
                    //Izquierda
                    Debug.DrawRay(sV.basePos.position, -sV.offset, Color.red);
                    //Derecha
                    Debug.DrawRay(sV.basePos.position, sV.offset, Color.red);
                }
            }

        }
    }

    private void OnDrawGizmos()
    {
        VisualRefs();
    }
}
