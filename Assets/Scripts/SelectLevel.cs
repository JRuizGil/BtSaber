using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    [Header("Nombre o índice del nivel a cargar")]
    public string EasyMode = "EasyMode";
    public string HardMode = "HardMode";


    
    public void CargarNivelFacil()
    {
        if (!string.IsNullOrEmpty(EasyMode))
        {
            SceneManager.LoadScene(EasyMode);
        }
        else
        {
            Debug.LogWarning("No se ha asignado un nombre de nivel.");
        }
    }
    public void CargarNivelDificil()
    {
        if (!string.IsNullOrEmpty(HardMode))
        {
            SceneManager.LoadScene(HardMode);
        }
        else
        {
            Debug.LogWarning("No se ha asignado un nombre de nivel.");
        }
    }
}

