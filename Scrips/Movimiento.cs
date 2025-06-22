using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Personajeprincipal : MonoBehaviour
{
    public float speed; // Velocidad de movimiento del personaje
    private Rigidbody2D rb; // Componente Rigidbody2D para la física
    private Animator Controlador; // Componente Animator para las animaciones
    private SpriteRenderer spritepersonaje; // Componente SpriteRenderer para el sprite del personaje

    // Inicialización de componentes
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D
        Controlador = GetComponent<Animator>(); // Obtener el componente Animator
        spritepersonaje = GetComponent<SpriteRenderer>(); // Obtener el componente SpriteRenderer
    }

    // Método llamado al inicio del juego
    private void FixedUpdate()
    {
       movimiento();
    }

    // Método para manejar el movimiento del personaje
    private void movimiento()
    {
        // Obtener las entradas del usuario para el movimiento horizontal y vertical
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Crear un vector de movimiento basado en las entradas y la velocidad
        Vector2 movimiento = new Vector2(horizontal, vertical) * speed;
        rb.linearVelocity = movimiento;

        // Actualizar las animaciones del personaje
        Controlador.SetFloat("Correr", Mathf.Abs(movimiento.magnitude));

        // Controlar la dirección del sprite según el movimiento horizontal
        if (horizontal > 0)
        {
            spritepersonaje.flipX = false;
        }
        else if (horizontal < 0)
        {
            spritepersonaje.flipX = true;
        }
    }
}
