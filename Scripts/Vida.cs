using UnityEngine;

public class Vida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Solo destruye el objeto si realmente se recuperó una vida
            bool vidaRecuperada = GameManager.Instance.RecuperarVida();

            if (vidaRecuperada)
            {
                Destroy(gameObject);
                Debug.Log("Vida recogida por: " + other.gameObject.name);
            }
            else
            {
                Debug.Log("El jugador ya tiene la vida máxima");
            }
        }
    }
}
