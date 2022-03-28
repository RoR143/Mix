using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Tag sobre el que este objeto aplicar� da�o.
    public string tagToDamage;

    // Cantidad de da�o.
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobamos si el objeto que ha entrado en el trigger tiene el tag que hemos configurado.
        if (collision.CompareTag(tagToDamage))
        {
            // Si es as�, intentamos acceder a su componente Destroyable.
            if (collision.TryGetComponent(out Destroyable d))
            {
                // Si conseguimos recuperarlo, le aplicamos el da�o.
                d.ApplyDamage();
            }
            else if (collision.TryGetComponent(out PlayerHealth h))
            {
                // Si no se puede acceder a Destroyable, probamos con PlayerHealth y aplicamos el da�o correspondiente.
                h.GetDamage(damage);
            }
        }
    }
}
