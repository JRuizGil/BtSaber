using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OSX;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Management;


public class SelectLevel : MonoBehaviour
{
    [Header("Nombre o �ndice del nivel a cargar")]
    public string EasyMode = "EasyMode";
    public string HardMode = "HardMode";
    [SerializeField]private Dropdown Puntos;
    [SerializeField]private Dropdown Mano;
    [SerializeField]private Toggle Dual;

    public GameObject ManoIzq;
    private GameObject Sableizq;
    public GameObject ManoDer;
    private GameObject Sableder;
    private static SelectLevel instance;
    public GameManager gameManager;
    public Puntuacion Puntuacion;

    private void Start()
    {
        gameManager.enabled = true;
        if (PlayerPrefs.HasKey("MaxPuntos"))
        {
            Puntuacion.maxPuntos = PlayerPrefs.GetInt("MaxPuntos");
        }
        RecoverSable();
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
                gm.enabled = true; 
                pt.enabled = true;
                RecoverSable();
                Debug.Log("GameManager activado en EasyMode.");             
            }
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
                gm.enabled = true; 
                pt.enabled = true;
                RecoverSable();
                Debug.Log("GameManager activado en EasyMode.");
                
            }
        }
    }
    public void ManoDom()
    {
        int pickedEntryIndexMano = Mano.value;        
        if (pickedEntryIndexMano == 1)
        {
            Dual.isOn = false;
            Sableder = ManoDer.transform.Find("XR Controller Right(Clone)").gameObject;
            Sableizq = ManoIzq.transform.Find("XR Controller Left(Clone)").gameObject;
            if (Sableder != null)
            {
                Sableder.SetActive(true);
            }
            if (Sableizq != null)
            {
                Sableizq.SetActive(false);
                Debug.Log("Mando izquierdo desactivado");
            }
            PlayerPrefs.SetInt("ManoDom", 1);
            PlayerPrefs.Save();
        }
        if (pickedEntryIndexMano == 2)
        {
            Dual.isOn = false;
            Sableder = ManoDer.transform.Find("XR Controller Right(Clone)").gameObject;
            Sableizq = ManoIzq.transform.Find("XR Controller Left(Clone)").gameObject;
            if (Sableizq != null)
            {
                Sableizq.SetActive(true);
            }
            if (Sableder != null)
            {
                Sableder.SetActive(false);
                Debug.Log("Mando derecho desactivado");
            }
            PlayerPrefs.SetInt("ManoDom", 2);
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
        Sableder = ManoDer.transform.Find("XR Controller Right(Clone)").gameObject;
        Sableizq = ManoIzq.transform.Find("XR Controller Left(Clone)").gameObject;

        if (Dual.isOn)
        {
            Mano.value = 0;
            PlayerPrefs.SetInt("ManoDom", 0);
            PlayerPrefs.Save();
            Sableizq.SetActive(true);
            Sableder.SetActive(true);
        }
        else
        {
            if (PlayerPrefs.GetInt("ManoDom") == 1)
            {
                Sableizq.SetActive(false);                
                Sableder.SetActive(true);
            }
            if (PlayerPrefs.GetInt("ManoDom") == 2)
            {                
                Sableizq.SetActive(true);                
                Sableder.SetActive(false);
            }
        }
    }
    public void RecoverSable()
    {
        Sableder = ManoDer.transform.Find("XR Controller Right(Clone)").gameObject;
        Sableizq = ManoIzq.transform.Find("XR Controller Left(Clone)").gameObject;
        if (PlayerPrefs.GetInt("ManoDom") == 0)
        {            
            Sableder.SetActive(true);
            Sableder.SetActive(true);
        }
        if (PlayerPrefs.GetInt("ManoDom") == 1)
        {            
            Sableder.SetActive(true);
            Sableder.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ManoDom") == 2)
        {            
            Sableder.SetActive(false);
            Sableder.SetActive(true);
        }
    }

}

