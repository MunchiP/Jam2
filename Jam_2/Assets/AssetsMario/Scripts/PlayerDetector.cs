using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            other.GetComponent<BodyPartAssembler>().ParteRecuperada();

            //Destruir este objeto para evitar que se use nuevamente para recuperar partes
            Destroy(gameObject);
        }
    }
}
