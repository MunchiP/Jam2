using UnityEngine;

public class CryOne : MonoBehaviour
{
    public Transform player; // Agregar al player en el inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entro a OnTriger");
        if (other.CompareTag("Player"))
        {

            AudioManager.Sound junglaSound = AudioManager.Instance.GetSound("cry_1");
            if (junglaSound != null && audioSource != null)
            {
                audioSource.clip = junglaSound.clip;
                audioSource.Play();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
