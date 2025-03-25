using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    public Text puntuacionText;
    private int puntos = 0;
    private int maxPuntos = 20;
    void Start()
    {
        ActualizarTexto();
    }
    public void AgregarPunto()
    {
        puntos++;
        ActualizarTexto();
        if (puntos >= maxPuntos)
        {
            CerrarJuego();
        }
    }    
    void ActualizarTexto()
    {
        if (puntuacionText != null)
        {
            puntuacionText.text = "Puntos: " + puntos;
        }
    }
    void CerrarJuego()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}

