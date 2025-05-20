using UnityEngine;

public class AdnSin : MonoBehaviour
{
    public int numberOfSpheres = 7;
    public float verticalSpacing = 1.5f;
    public float amplitude = 1f;
    public float frequency = 1f;
    public float rayLength = 15f;
 
    private GameObject[] spheres;
    private LineRenderer[] lines;


    void Start()
    {
        spheres = new GameObject[numberOfSpheres];
        lines = new LineRenderer[numberOfSpheres];
        Create();
    }

    void Create()
    {
        for (int i = 0; i < numberOfSpheres; i++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.parent = transform;
            sphere.transform.localPosition = new Vector3(0, -i * verticalSpacing, 0);
            sphere.GetComponent<MeshRenderer>().material.color = i % 2 == 0 ? Color.red : Color.blue;
            spheres[i] = sphere;

            // Agregar LineRenderer
            LineRenderer lr = sphere.AddComponent<LineRenderer>();
            lr.positionCount = 2;
            lr.material = new Material(Shader.Find("Sprites/Default"));
            lr.startColor = Color.yellow;
            lr.endColor = Color.yellow;
            lr.startWidth = 0.05f;
            lr.endWidth = 0.05f;
            lr.useWorldSpace = true;
            lines[i] = lr;
        }
    }

    void Update()
    {
        float time = Time.time;
        for (int i = 0; i < numberOfSpheres; i++)
        {
            Vector3 pos = spheres[i].transform.localPosition;
            pos.x = Mathf.Sin(time * frequency + i * 0.5f) * amplitude;
            spheres[i].transform.localPosition = pos;

            // Actualizar línea visual del rayo
            Vector3 worldPos = spheres[i].transform.position;
            lines[i].SetPosition(0, worldPos);
            lines[i].SetPosition(1, worldPos + Vector3.left * rayLength);
        }
    }
}
