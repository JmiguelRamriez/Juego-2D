using UnityEngine;
using TMPro; // Asegúrate de tener el espacio de nombres correcto para TextMeshPro0
using System.Collections;
using System.Collections.Generic;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI puntos; // Asegúrate de tener el espacio de nombres correcto para TextMeshPro
    public GameObject[] vidas;
    [SerializeField] private GameObject cartel;
    [SerializeField] private TMP_Text textoDialogo;

    void Update()
    {
        // Actualiza el texto de puntos en el HUD
        puntos.text = GameManager.Instance.PuntosTotales.ToString();
    }

    public void ActualizarPuntos(int puntosTotales)
    {
        // Actualiza el texto de puntos en el HUD
        puntos.text = puntosTotales.ToString();
    }

    public void DesactivarVida(int index)
    {
    vidas[index].SetActive(false);
    }

    public void ActivarVida(int index)
    {
    vidas[index].SetActive(true);
    }

    public void ActivarDesactivaCartel(bool activado)
    {
        cartel.SetActive(activado);
    }

    public void MostrarTexto(string texto)
    {
        textoDialogo.text = texto.ToString();
    }

    private void Start()
    {
        ActivarDesactivaCartel(false);
    }
}
