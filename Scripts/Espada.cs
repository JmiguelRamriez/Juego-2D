using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Espada : MonoBehaviour
{
    private BoxCollider2D colEspada;

    private void Awake()
    {
        colEspada = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión detectada con: " + other.gameObject.name);

        if (other.CompareTag("Enemigo"))
        {
            Debug.Log("Enemigo detectado - destruyendo objeto");
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Objeto golpeado no es un enemigo: " + other.tag);
        }

    }
}
