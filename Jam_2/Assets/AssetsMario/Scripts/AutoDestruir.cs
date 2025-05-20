using System.Collections;
using UnityEngine;

public class AutoDestruir : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(autoDdestroy());
    }

    IEnumerator autoDdestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);

    }

}
