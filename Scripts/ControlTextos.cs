using UnityEngine;

public class ControlTextos : MonoBehaviour
{
    [SerializeField, TextArea(3, 10)] private string[] arrayTexto;
    [SerializeField] private HUD hud;
    [SerializeField] private Personajeprincipal personaje;

    private int indexTexto = 0;
    private bool jugadorCerca = false;
    private bool mostrandoTexto = false;


    private void Awake()
    {
        personaje = GameObject.FindWithTag("Player").GetComponent<Personajeprincipal>();
        if (hud == null)
        {
            hud = FindAnyObjectByType<HUD>();
        }
    }


    private void Update()
    {
        float distancia = Vector2.Distance(transform.position, personaje.transform.position);

        if (distancia <= 2f)
        {
            if (!jugadorCerca)
            {
                jugadorCerca = true;
                indexTexto = 0;
                mostrandoTexto = true;
                hud.ActivarDesactivaCartel(true);
                hud.MostrarTexto(arrayTexto[indexTexto]);
            }

            if (mostrandoTexto && Input.GetKeyDown(KeyCode.E))
            {
                indexTexto++;
                if (indexTexto < arrayTexto.Length)
                {
                    hud.MostrarTexto(arrayTexto[indexTexto]);
                }
                else
                {
                    hud.ActivarDesactivaCartel(false);
                    mostrandoTexto = false;
                }
            }
        }
        else
        {
            if (jugadorCerca)
            {
                jugadorCerca = false;
                mostrandoTexto = false;
                indexTexto = 0;
                hud.ActivarDesactivaCartel(false);
            }
        }
    }
}

