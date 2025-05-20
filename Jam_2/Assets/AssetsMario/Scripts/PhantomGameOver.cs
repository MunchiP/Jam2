using UnityEngine;
using UnityEngine.SceneManagement;

public class PhantomGameOver : MonoBehaviour
{
    public bool oscilate;
    [SerializeField] private float amplitud = 2f; // Distancia m�xima desde la posici�n inicial (izquierda/derecha)
    [SerializeField] private float velocidad = 2f; // Qu� tan r�pido oscila

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (oscilate)
        {
            float desplazamiento = Mathf.Sin(Time.time * velocidad) * amplitud;
            transform.position = new Vector3(posicionInicial.x + desplazamiento, posicionInicial.y, posicionInicial.z);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
