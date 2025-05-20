using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    private  Transform player;
    [SerializeField] float speed = 1.2f;
    Vector3 playerPosition;
    private SpawnerEnemy spawnerEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     playerPosition = player.transform.position; 
       
    // }

        void OnEnable(){
            player = GameObject.FindWithTag("Player").transform;
            spawnerEnemy = FindAnyObjectByType<SpawnerEnemy>();
            playerPosition = player.position;
        }

    // Update is called once per frame
    void Update()
    {
       
       MoveToPlayer();
       DestroyWhenReached();
    }

    void MoveToPlayer(){
          transform.position = Vector3.MoveTowards(transform.position,playerPosition,speed * Time.deltaTime);
    }

    void DestroyWhenReached(){
        if(Vector3.Distance(transform.position,playerPosition) <0.17f){
            spawnerEnemy.EnQuueProjectile(gameObject);
        }
    }
}
