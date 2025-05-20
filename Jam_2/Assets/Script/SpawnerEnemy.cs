using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] GameObject projectilPrefab;
    private Queue<GameObject> pool = new Queue<GameObject>();
    private int poolSize = 5;
    private float randomPosition;
    
    
    void Start()
    {
        AddToPool(poolSize);
    }

    void AddToPool(int size) {
        for (int i = 0; i < size; i++)
        {
            GameObject projectil = Instantiate(projectilPrefab, origin.position, origin.rotation);
            projectil.SetActive(false);
            
            projectil.transform.SetParent(origin.transform);
            pool.Enqueue(projectil);
             
        }
    }

   public  void SpawnerAllProjectiles(){
    int count = pool.Count;
        for (int i = 0; i < count; i++)
        {
            randomPosition = Random.Range(1.2f,9.0f);
            GameObject projectil = pool.Dequeue();
            projectil.transform.position = origin.position + new Vector3(1,0.5f,1)* randomPosition;
            projectil.transform.rotation = origin.rotation;
            projectil.SetActive(true);
        }
        
    }

   public  void EnQuueProjectile(GameObject projectile){
        projectile.gameObject.SetActive(false);
        pool.Enqueue(projectile);
    }

    void Update()
    {
        
    }


}
