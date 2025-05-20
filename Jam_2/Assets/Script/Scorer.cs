using UnityEngine;

public class Scorer : MonoBehaviour
{
    private int points;

    void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Hit")){
            points++;
            Debug.Log($"Puntos : {points}");
            
        }
    }
}
