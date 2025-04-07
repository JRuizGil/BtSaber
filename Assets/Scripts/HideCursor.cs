using UnityEngine;
using UnityEngine.EventSystems;

public class HideCursor : MonoBehaviour
{
    [Header("Ocultar el cursor tradicional del ratón")]
    public bool ocultarCursor = true;

    private StandaloneInputModule inputModule;

    void Start()
    {
        // Buscar el StandaloneInputModule (el que maneja el mouse en UI)
        inputModule = FindObjectOfType<StandaloneInputModule>();

        if (ocultarCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            if (inputModule != null)
            {
                inputModule.enabled = false; // Desactiva interacción con UI vía mouse
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            if (inputModule != null)
            {
                inputModule.enabled = true; // Reactiva UI para mouse si lo necesitas
            }
        }
    }
}
