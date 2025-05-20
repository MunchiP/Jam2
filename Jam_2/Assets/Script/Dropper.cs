using System.Collections;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float timeToWait = 0.8f;
    MeshRenderer myMeshRender;
    Rigidbody rbDropper;
    private bool isActive= false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myMeshRender = GetComponent<MeshRenderer>();
        rbDropper = GetComponent<Rigidbody>();
        myMeshRender.enabled = false;
        rbDropper.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {

       
    }
    public void Activate()
    {
        isActive = true;
        StartCoroutine(ActivateDropper());
    }

    private IEnumerator ActivateDropper()
    {
        yield return new WaitForSeconds(1);
        ChangeDropper();
        Destroy(gameObject, 3.8f);
    }


    void ChangeDropper(){
        myMeshRender.enabled = true;
        rbDropper.useGravity = true;
    }
}
