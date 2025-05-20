using UnityEngine;

public class BodyPartAssembler : MonoBehaviour
{
    [Header("Estado Inicial")]
    [Range(0, 4)]
    public int valorEstadoInicial;

    public SkinnedMeshRenderer skinPlayer;
    public Mesh[] meshParts = new Mesh[5];

    int numPart = 0; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numPart = valorEstadoInicial;

        //Habilitar la posición inicial del cuerpo      
        skinPlayer.sharedMesh = meshParts[numPart];       
    }



    public void ParteRecuperada()
    {
        //Activar el nuevo
        numPart++;
        if (numPart < meshParts.Length)
            skinPlayer.sharedMesh = meshParts[numPart];
    }



}
