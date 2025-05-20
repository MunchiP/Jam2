using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float floatAmplitude = 0.5f; // Amplitud de la flotación
    public float floatSpeed = 2f; // Velocidad de la flotación

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // Guardamos la posición inicial
    }

    void Update()
    {
        // Aplicamos un movimiento vertical oscilatorio
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

