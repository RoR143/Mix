using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulledObject : MonoBehaviour
{
    // Referencia al objeto padre que tiene este objeto cuando empieza el juego
    public Transform startingParent;

    public virtual void Initialise()
    {

    }

    public void ResetPulledObject()
    {
        // Se restablece el padre del objeto
        transform.SetParent(startingParent);
        // Reseteamos la velocidad
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // Reseteamos la posición
        transform.localPosition = Vector2.zero;
        // Desactivamos el objeto
        gameObject.SetActive(false);

    }
}
