using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Referencia al objeto que contiene aquellos items que vamos a extraer con esta pool.
    public Transform container;
    // Referencia al objeto que crearemos si la pool se queda vacía.
    public GameObject objectRef;

    GameObject AddObject()
    {
        // Instanciamos y devolvemos la referencia del objeto.
        return Instantiate(objectRef);
    }

    public GameObject ExtractObject()
    {
        //Variable local para almacenar el objeto extraido
        GameObject objectRef;

        //Si la cantidad de objetos en el contenedor es superior a 0,
        if (container.childCount > 0)
        {
            // Se asigna el primer hijo del contenedor a la referencia
            objectRef = container.GetChild(0).gameObject;
        }
        else
        {
            objectRef = AddObject();
        }

        // Se desemparenta el objeto extraido
        objectRef.transform.SetParent(null);

        // Se activa
        objectRef.SetActive(true);

        // Se devuelve
        return objectRef;
    }
}
