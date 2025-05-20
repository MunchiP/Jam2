using UnityEngine;

public class HitPoint : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")){

           GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
           gameObject.tag = "Hit";
        }
    }
}
