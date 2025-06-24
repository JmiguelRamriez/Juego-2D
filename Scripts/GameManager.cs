using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Instancia única del GameManager
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    private int vidas = 3; // Total de vidas del jugador

    public HUD hud; // Referencia al HUD para actualizar la interfaz

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Buscar HUD si no está asignado
            if (hud == null)
                hud = FindFirstObjectByType<HUD>();
        }
        else
        {
            Debug.LogWarning("Intentando crear una segunda instancia de GameManager");
            Destroy(gameObject); // importante para evitar duplicados
        }
    }


    public void SumarPuntos(int puntos)
    {
        puntosTotales += puntos;
        Debug.Log("Puntos totales: " + puntosTotales);
        hud.ActualizarPuntos(puntosTotales); // Actualiza el HUD con los nuevos puntos
    }

    public void RestarVida()
    {
    vidas--;
        if (vidas == 0)
        {
            SceneManager.LoadScene("Nivel 1"); // Cargar la escena de Game Over
        }
        // Actualizar el HUD para reflejar la vida restante
        hud.DesactivarVida(vidas);
    }


    public bool RecuperarVida()
    {
        if (vidas < 3) // Cambia 3 por tu límite de vidas si es otro
        {
            vidas++;
            hud.ActivarVida(vidas - 1);
            return true;
        }

        return false;
    }

}
