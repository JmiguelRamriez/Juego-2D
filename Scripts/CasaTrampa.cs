using UnityEngine;

public class CasaTrampa : MonoBehaviour
{
    [SerializeField] private HUD hud;
    [SerializeField, TextArea(2, 5)] private string mensaje = "Algo no est� bien aqu� Ser� mejor no entrar.";

    private bool yaMostro = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!yaMostro && other.CompareTag("Player"))
        {
            hud.ActivarDesactivaCartel(true);
            hud.MostrarTexto(mensaje);
            yaMostro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hud.ActivarDesactivaCartel(false);
            yaMostro = false;
        }
    }
}
