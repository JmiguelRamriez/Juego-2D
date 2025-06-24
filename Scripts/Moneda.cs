using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valor = 1; // Valor de la moneda, puedes ajustarlo seg�n tus necesidades


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SumarPuntos(valor); // Suma los puntos al GameManager
            // Destruye el objeto de la moneda
            Destroy(gameObject);
            // Aqu� podr�as agregar l�gica para aumentar el puntaje del jugador
            Debug.Log("Moneda recogida por: " + other.gameObject.name);
        }
    }
}
