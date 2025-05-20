using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance; // Singleton: accede de manera fáci desde otros scripts
    [System.Serializable]
    public class Sound
    {
        public string name; // Nombre del audio - inspector
        public AudioClip clip; // Archivo de audio - inspector
    }

    public List<Sound> sounds = new List<Sound>(); // Lista de los sonidos que se agregan en el inspector


    private void Awake()
    {
        if (Instance == null) // Si no existe ningúna otra referencia de AudioManager
        {
            Instance = this; // Entonces use esta
            DontDestroyOnLoad(gameObject); // Evita que se destruya el audio manager al cambiar de scena
        }
    }

    public Sound GetSound(string soundName) // Si encuentra un sonido lo devuelve para el backgrund
    {
        Sound sonido = sounds.Find(x => x.name == soundName); // Busca el sonido por el nombre

        if (sonido != null)
        {
            Debug.Log("Sonido encontrado: " + soundName);
        }

        return sonido;
    }

    public void PlayOneTime(string soundName, AudioSource source) // Para los sonidos dentro de las zonas
    {
        Sound sonido = sounds.Find(x => x.name == soundName);

        if (sonido != null && source != null)
        {
            source.PlayOneShot(sonido.clip);
        }
    }
}
