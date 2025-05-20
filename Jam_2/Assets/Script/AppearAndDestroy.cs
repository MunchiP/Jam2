using UnityEngine;
using System.Collections.Generic;

public class AppearAndDestroy : MonoBehaviour
{
    public GameObject trofeo;  
    public GameObject fanUno;
    public GameObject fanDos;
    public GameObject fanTres;

    private HashSet<GameObject> fantasmasTocados = new HashSet<GameObject>(); // Almacena los fantasmas tocados por el jugador

    void Start()
    {
        trofeo.SetActive(false); // Aseguramos que el objeto esté desactivado al inicio
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto con el que colisionamos es uno de los fantasmas
        if (other.gameObject == fanUno || other.gameObject == fanDos || other.gameObject == fanTres)
        {
            // Agregamos el fantasma tocado a la lista
            fantasmasTocados.Add(other.gameObject);
            
            // Si todos los fantasmas han sido tocados, activamos el trofeo
            if (fantasmasTocados.Count == 3)
            {
                trofeo.SetActive(true);
                Debug.Log("¡Trofeo activado!");
            }
        }
    }
}

