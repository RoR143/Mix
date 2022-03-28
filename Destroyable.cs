using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroyable : MonoBehaviour
{
    // Acciones que se lanzaran cuando el objeto sea reseteado.
    public UnityEvent onResetActions;

    public void ApplyDamage()
    {
        // Invocamos el evento para lanzar las acciones asignadas cuando se resetea el objeto.
        onResetActions.Invoke();
        // Reseteamos el objeto.
        GetComponent<PulledObject>().ResetPulledObject();
    }
}
