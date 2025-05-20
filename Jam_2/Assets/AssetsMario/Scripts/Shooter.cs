using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform player;            // Referencia al jugador
    public float shootInterval = 3f;    // Intervalo de disparo en segundos
    public float projectileSpeed = 10f; // Velocidad del proyectil

    private float shootTimer;

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            ShootAtPlayer();
            shootTimer = 0f;
        }
    }

    void ShootAtPlayer()
    {
        if (projectilePrefab == null || player == null) return;

        // Instanciar proyectil
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Calcular dirección hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;

        // Aplicar velocidad
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * projectileSpeed;
        }
    }
}

