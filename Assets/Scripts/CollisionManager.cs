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
                puntuacionScript.AgregarPunto(); 
                Destroy(other.transform.parent.gameObject);
            }
            else if (notPoint != null)
            {
                if (other.transform.parent != null)
                {
                    Destroy(other.transform.parent.gameObject); 
                    puntuacionScript.RestarPunto();
                }
                else
                {
                    Destroy(other.gameObject); 
                }
            }
            else
            {
                Destroy(other.gameObject); 
            }

            Debug.Log("Objeto destruido");
        }
    }
}

