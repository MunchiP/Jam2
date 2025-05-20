// using UnityEngine;

// public class OcultarPates : MonoBehaviour
// {


//     void Start()
//     {

//         // foreach (Transform child in transform.GetComponentsInChildren<Transform>())
//         // {
//         //     Debug.Log(child.name);
//         // }

//         // Transform Per = transform;

//         // Transform piernaIzquierda = Per.Find("Ch34.001");

//         Transform falda = FindDeepChild(transform, "Ch34.001");

//         // if (falda != null)
//         // {
//         //     falda.localScale = Vector3.zero;
//         // }
//         // else
//         // {
//         //     falda.gameObject.SetActive(true);
//         // }

//     if (falda != null)
//         {
//             falda.gameObject.SetActive(true);
//             Debug.Log("Falda activada.");
//         }

//     }

//     Transform FindDeepChild(Transform parent, string name)
//     {
//         foreach (Transform child in parent)
//         {
//             if (child.name == name)
//                 return child;
//             Transform result = FindDeepChild(child, name);
//             if (result != null)
//                 return result;
//         }
//         return null;
//     }
// }


// using UnityEngine;

// public class MostrarFalda : MonoBehaviour
// {
//     public GameObject falda;  // ← arrastrar aquí en el editor

//     void Start()
//     {
//         if (falda != null)
//         {
//             falda.SetActive(true);
//             Debug.Log("Falda activada desde Inspector.");
//         }
//         else
//         {
//             Debug.LogWarning("No se asignó la falda en el Inspector.");
//         }
//     }
// }


using UnityEngine;

public class OcultarPates : MonoBehaviour
{
    public string nombreObjeto = "Ch34.001"; // Nombre del objeto a controlar
    private GameObject objetoControlado;

    void Start()
    {
        // Buscar el objeto por su nombre utilizando la función FindDeepChild
        Transform objetoTransform = FindDeepChild(transform, nombreObjeto);

        if (objetoTransform != null)
        {
            objetoControlado = objetoTransform.gameObject;
            // Desactivar el objeto al inicio
            objetoControlado.SetActive(false);
            Debug.Log(nombreObjeto + " desactivado al inicio.");
        }
        else
        {
            Debug.LogError("No se encontró el objeto con el nombre: " + nombreObjeto + " dentro de los hijos de " + gameObject.name);
        }
    }

    void Update()
    {
        // Detectar el clic del botón izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            // Verificar si el objeto fue encontrado y si está actualmente desactivado
            if (objetoControlado != null && !objetoControlado.activeSelf)
            {
                // Activar el objeto al hacer clic
                objetoControlado.SetActive(true);
                Debug.Log(nombreObjeto + " activado con un clic.");
            }
        }
    }

    Transform FindDeepChild(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
                return child;
            Transform result = FindDeepChild(child, name);
            if (result != null)
                return result;
        }
        return null;
    }
}