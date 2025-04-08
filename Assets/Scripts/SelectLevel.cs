using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OSX;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    [Header("Nombre o índice del nivel a cargar")]
    public string EasyMode = "EasyMode";
    public string HardMode = "HardMode";
    [SerializeField]private Dropdown Puntos;
    [SerializeField]private Dropdown Mano;
    [SerializeField]private Toggle Dual;

    public GameObject ManoIzq;
    public GameObject ManoDer;

    public GameManager gameManager;
    public Puntuacion Puntuacion;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MaxPuntos"))
        {
            Puntuacion.maxPuntos = PlayerPrefs.GetInt("MaxPuntos");
        }
        else
        {
            Puntuacion.maxPuntos = 10; // Valor por defecto si no existe
        }
    }
    public void CargarNivelFacil()
    {
        if (!string.IsNullOrEmpty(EasyMode))
        {
            SceneManager.LoadScene(EasyMode);
            GameManager gm = GetComponent<GameManager>();
            Puntuacion pt = GetComponent<Puntuacion>();
            if (gm != null)
            {
                gm.spawnInterval = 2f;
                gm.speed = 2f;
                gm.enabled = true; // Activa el script GameManager
                pt.enabled = true;
                Debug.Log("GameManager activado en EasyMode.");
            }
            else
            {
                Debug.LogWarning("No se encontró el componente GameManager en este objeto.");
            }
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
            GameManager gm = GetComponent<GameManager>();
            Puntuacion pt = GetComponent<Puntuacion>();
            if (gm != null)
            {
                gm.spawnInterval = 1f;
                gm.speed = 3f;
                gm.enabled = true; // Activa el script GameManager
                pt.enabled = true;
                Debug.Log("GameManager activado en EasyMode.");
            }
            else
            {
                Debug.LogWarning("No se encontró el componente GameManager en este objeto.");
            }
        }
        else
        {
            Debug.LogWarning("No se ha asignado un nombre de nivel.");
        }
    }
    public void ManoDom()
    {
        int pickedEntryIndexMano = Mano.value;

        GameObject leftHandController = GameObject.Find("Left Controller");
        GameObject rightHandController = GameObject.Find("Right Controller");

        if (pickedEntryIndexMano == 0)
        {
            if (rightHandController != null)
            {
                ActivarJerarquia(ManoDer);
            }
            if (leftHandController != null)
            {
                leftHandController.SetActive(false);
                Debug.Log("Mando izquierdo desactivado");
            }
            PlayerPrefs.SetInt("ManoDom", Mano.value);
            PlayerPrefs.Save();
        }

        if (pickedEntryIndexMano == 1)
        {
            if (leftHandController != null)
            {
                ActivarJerarquia(ManoIzq);
            }
            if (rightHandController != null)
            {
                rightHandController.SetActive(false);
                Debug.Log("Mando derecho desactivado");
            }
            PlayerPrefs.SetInt("ManoDom", Mano.value);
            PlayerPrefs.Save();
        }
    }

    public void ObtenDropDownValue()
    {
        int pickedEntryIndex = Puntos.value;
        if(pickedEntryIndex == 0)
        {
            Puntuacion.maxPuntos = 10;
            Debug.Log("puntuacion actual " + Puntuacion.maxPuntos);
            PlayerPrefs.SetInt("MaxPuntos", Puntuacion.maxPuntos);
            PlayerPrefs.Save();
        }
        if (pickedEntryIndex == 1)
        {
            Puntuacion.maxPuntos = 20;
            Debug.Log("puntuacion actual " + Puntuacion.maxPuntos);
            PlayerPrefs.SetInt("MaxPuntos", Puntuacion.maxPuntos);
            PlayerPrefs.Save();

        }
        if (pickedEntryIndex == 2)
        {
            Puntuacion.maxPuntos = 30;
            Debug.Log("puntuacion actual " + Puntuacion.maxPuntos);
            PlayerPrefs.SetInt("MaxPuntos", Puntuacion.maxPuntos);
            PlayerPrefs.Save();
        }
    }
    public void ManoDual(bool togglevalue)
    {
        GameObject leftHandController = GameObject.Find("Left Controller");
        GameObject rightHandController = GameObject.Find("Right Controller");

        if (Dual.isOn)
        {
            if (leftHandController != null)
                ActivarJerarquia(ManoIzq);

            if (rightHandController != null)
                ActivarJerarquia(ManoDer);
        }
        else
        {
            if (PlayerPrefs.GetInt("ManoDom") == 0)
            {
                if (leftHandController != null && leftHandController.activeSelf)
                    leftHandController.SetActive(false);

                if (rightHandController != null && !rightHandController.activeSelf)
                    ActivarJerarquia(ManoDer);
            }
            if (PlayerPrefs.GetInt("ManoDom") == 1)
            {
                if (leftHandController != null && !leftHandController.activeSelf)
                    ActivarJerarquia(ManoIzq);

                if (rightHandController != null && rightHandController.activeSelf)
                    rightHandController.SetActive(false);
            }
        }
    }

    void ActivarJerarquia(GameObject obj)
    {
        Transform actual = obj.transform;
        while (actual != null)
        {
            actual.gameObject.SetActive(true);
            actual = actual.parent;
        }
    }

}

