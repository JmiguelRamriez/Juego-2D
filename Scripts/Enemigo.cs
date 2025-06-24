using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad = 2f;
    public float rangoPatrulla = 2f;
    public float rangoVision = 4f;
    public float rangoAtaque = 1f;
    public float limitePersecucion = 6f;
    public float delayDanio = 0.5f;

    private Vector3 puntoA;
    private Vector3 puntoB;
    private Vector3 objetivoActual;

    private Transform jugador;
    private SpriteRenderer sr;
    private bool persiguiendo = false;

    private Animator anim;
    private bool puedeAtacar = true;
    public float tiempoEntreAtaques = 1;

    private Vector3 posicionInicial;

    private void Start()
    {
        anim = GetComponent<Animator>();

        posicionInicial = transform.position;

        puntoA = posicionInicial + Vector3.left * rangoPatrulla;
        puntoB = posicionInicial + Vector3.right * rangoPatrulla;
        objetivoActual = puntoB;

        sr = GetComponent<SpriteRenderer>();

        jugador = GameObject.FindWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (jugador == null)
            return;

        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        float distanciaInicial = Vector2.Distance(posicionInicial, jugador.position);

        if (distanciaJugador <= rangoVision && distanciaInicial <= limitePersecucion)
        {
            persiguiendo = true;

            if (distanciaJugador <= rangoAtaque)
            {
                Atacar();
            }
            else
            {
                SeguirJugador();
            }
        }
        else
        {
            persiguiendo = false;
            Patrullar();
        }
    }

    private void Patrullar()
    {
        transform.position = Vector2.MoveTowards(transform.position, objetivoActual, velocidad * Time.deltaTime);

        if (Vector2.Distance(transform.position, objetivoActual) < 0.1f)
        {
            objetivoActual = (objetivoActual == puntoA) ? puntoB : puntoA;
        }

        sr.flipX = (objetivoActual.x > transform.position.x);
    }

    private void SeguirJugador()
    {
        transform.position = Vector2.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);

        sr.flipX = (jugador.position.x > transform.position.x);
    }

    private void Atacar()
    {
        if (!puedeAtacar) return;

        puedeAtacar = false;
        anim.SetTrigger("Ataca");
        Debug.Log("¡Enemigo ataca!");

        Invoke(nameof(AplicarDanio), delayDanio);

        Invoke(nameof(ReiniciarAtaque), tiempoEntreAtaques);
    }

    private void AplicarDanio()
    {
        if (jugador != null && Vector2.Distance(transform.position, jugador.position) <= rangoAtaque)
        {
            GameManager.Instance.RestarVida(); // Daño aplicado con delay
            Debug.Log("Daño aplicado con retraso");
        }
    }

    private void ReiniciarAtaque()
    {
        puedeAtacar = true;
    }

}