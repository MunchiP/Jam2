using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;

    private float rotationY = 0f;
    private float rotationX = 0f;

    void Update()
    {
        // Movimiento de la cámara
        float horizontal = Input.GetAxis("Horizontal"); // A/D o Flechas izquierda/derecha
        float vertical = Input.GetAxis("Vertical"); // W/S o Flechas arriba/abajo
        float upDown = 0f;

        if (Input.GetKey(KeyCode.Space)) upDown = 1f; // Subir con espacio
        if (Input.GetKey(KeyCode.LeftControl)) upDown = -1f; // Bajar con Ctrl izquierdo

        Vector3 movement = new Vector3(horizontal, upDown, vertical) * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        // Rotación de la cámara con el mouse
        rotationY += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limita la inclinación para evitar giros incómodos

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }
}



