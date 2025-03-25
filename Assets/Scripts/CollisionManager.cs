using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private Puntuacion puntuacionScript;
    private AddPoint AddPoint;
    private NotPoint NotPoint;

    private void Start()
    {
        puntuacionScript = FindObjectOfType<Puntuacion>(); // Encuentra el script Puntuacion en la escena
        AddPoint = FindAnyObjectByType<AddPoint>();
        NotPoint = FindAnyObjectByType<NotPoint>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            AddPoint addPoint = other.GetComponent<AddPoint>();
            NotPoint notPoint = other.GetComponent<NotPoint>();

            if (addPoint != null && puntuacionScript != null)
            {
                puntuacionScript.AgregarPunto(); // Suma un punto
                Destroy(other.transform.parent.gameObject);
            }
            else if (notPoint != null)
            {
                if (other.transform.parent != null)
                {
                    Destroy(other.transform.parent.gameObject); // Destruye el padre si existe
                }
                else
                {
                    Destroy(other.gameObject); // Si no tiene padre, destruye solo el objeto
                }
            }
            else
            {
                Destroy(other.gameObject); // Destruye normalmente si no tiene esos scripts
            }

            Debug.Log("Objeto destruido");
        }
    }
}

