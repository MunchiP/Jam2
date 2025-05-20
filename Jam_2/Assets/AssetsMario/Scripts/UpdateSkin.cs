using UnityEngine;

public class UpdateSkin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<BodyPartAssembler>().ParteRecuperada();
            Destroy(gameObject);
        }
    }
}
