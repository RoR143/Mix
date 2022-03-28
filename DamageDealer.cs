using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Tag sobre el que este objeto aplicará daño.
    public string tagToDamage;

    // Cantidad de daño.
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobamos si el objeto que ha entrado en el trigger tiene el tag que hemos configurado.
        if (collision.CompareTag(tagToDamage))
        {
            // Si es así, intentamos acceder a su componente Destroyable.
            if (collision.TryGetComponent(out Destroyable d))
            {
                // Si conseguimos recuperarlo, le aplicamos el daño.
                d.ApplyDamage();
            }
            else if (collision.TryGetComponent(out PlayerHealth h))
            {
                // Si no se puede acceder a Destroyable, probamos con PlayerHealth y aplicamos el daño correspondiente.
                h.GetDamage(damage);
            }
        }
    }
}
