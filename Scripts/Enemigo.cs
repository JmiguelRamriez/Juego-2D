using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemigo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.RestarVida();
            Debug.Log("Enemigo ha colisionado con el jugador: " + other.gameObject.name);
        }
    }
}
