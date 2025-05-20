using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xRotate=0f;
    [SerializeField] float yRotate = 0.89f;
    [SerializeField] float zRotate = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRotate,yRotate,zRotate);
    }
}
