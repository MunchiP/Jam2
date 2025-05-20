using System.Collections.Generic;
using UnityEngine;

public class TriggerProjectile : MonoBehaviour
{
   
   [SerializeField] SpawnerEnemy spawnerEnemy;


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            spawnerEnemy.SpawnerAllProjectiles();
        }
    }
}
