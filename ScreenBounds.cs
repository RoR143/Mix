using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    // Vector para almacenar los límites de la pantalla.
    Vector2 screenLimits;
    // Vector para añadir offsets a dichos límites.
    public Vector2 offsets;
    // Valor para evitar que el jugador se quede atascado en dichos límites en un loop infinito de teleportación entre los mismos.
    public float boundCorrect;
    // Enumerador con lo que puede suceder cuando el objeto sale del campo de visión.
    public enum OutOfCameraBehavior
    {
        Mirror,
        Reset
    }

    // Variable para seleccionar qué hace el objeto cuando sale del campo de visión.
    public OutOfCameraBehavior oCB;

    private void Start()
    {
        // Obtenemos los límites de la pantalla usando la cámara y convirtiéndolos a posición del mundo. De esta forma la comprobación funcionará independientemente de la resolución del juego.
        screenLimits = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));
        // Añadimos los offsets para objetos que lo requieran.
        screenLimits += offsets;
    }

    private void Update()
    {
        // Comprobamos si el jugador está saliendo de los límites.
        BoundMirror();
    }

    void BoundMirror()
    {
        switch (oCB)
        {
            case OutOfCameraBehavior.Mirror:
                // Comprobamos si el jugador se ha salido de la pantalla en el eje horizontal o x por la derecha.
                if (transform.position.x > screenLimits.x)
                {
                    // Si es así, invertimos su posición en X, sumando el boundCorrect.
                    transform.position = new Vector2(-transform.position.x + boundCorrect, transform.position.y);
                }
                // Comprobamos si el jugador se ha salido de la pantalla en el eje horizontal o x por la izquierda.
                if (transform.position.x < -screenLimits.x)
                {
                    // Si es así, invertimos su posición en X, restando el boundCorrect.
                    transform.position = new Vector2(-transform.position.x - boundCorrect, transform.position.y);
                }
                // Comprobamos si el jugador se ha salido de la pantalla en el eje vertical o y por arriba.
                if (transform.position.y > screenLimits.y)
                {
                    // Si es así, invertimos su posición en Y, sumando el boundCorrect.
                    transform.position = new Vector2(transform.position.x, -transform.position.y + boundCorrect);
                }
                // Comprobamos si el jugador se ha salido de la pantalla en el eje vertical o y por debajo.
                if (transform.position.y < -screenLimits.y)
                {
                    // Si es así, invertimos su posición en Y, restando el boundCorrect.
                    transform.position = new Vector2(transform.position.x, -transform.position.y - boundCorrect);
                }
                break;
            case OutOfCameraBehavior.Reset:
                // Comprobamos si el objeto ha salido por cualquier lado de la pantalla.
                if (Mathf.Abs(transform.position.x) > screenLimits.x || Mathf.Abs(transform.position.y) > screenLimits.y)
                {
                    // Si sale, intentamos recuperar su componente PulledObject.
                    if (TryGetComponent(out PulledObject pO))
                    {
                        // Si se consigue, lo reseteamos.
                        pO.ResetPulledObject();
                    }
                    else
                    {
                        // Si no, mostramos un aviso en consola.
                        Debug.LogWarning("Se ha intentado resetear un objeto que no tiene el script PulledObject");
                    }
                }
                break;
        }

    }
}
