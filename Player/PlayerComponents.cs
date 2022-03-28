using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponents : MonoBehaviour
{
    [HideInInspector]
    // Referencia al rigidbody.
    public Rigidbody2D rB;

    [HideInInspector]
    // Referencia al ObjectPool.
    public ObjectPool oP;

    // Referencia al sistema de control.
    public Controls c;

    private void Awake()
    {
        // Inicializamos el sistema de control.
        c = new Controls();

        // Recuperamos la referencia.
        rB = GetComponent<Rigidbody2D>();
        oP = GetComponent<ObjectPool>();
    }
    private void OnEnable()
    {
        // Activamos el sistema de control.
        c.Enable();
    }
    private void OnDisable()
    {
        // Desactivamos el sistema de control.
        c.Disable();
    }
}
