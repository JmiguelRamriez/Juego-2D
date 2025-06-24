using UnityEngine;
using UnityEngine.SceneManagement;

public class EntradaCasa : MonoBehaviour
{
    [SerializeField] private string nombreEscenaDestino = "InteriorCasa"; // nombre exacto de la escena

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nombreEscenaDestino);
        }
    }
}
