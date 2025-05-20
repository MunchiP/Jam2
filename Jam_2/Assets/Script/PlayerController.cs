using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Flechas izquierda/derecha
        float vertical = Input.GetAxis("Vertical"); // Flechas arriba/abajo

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
        
    }
}



