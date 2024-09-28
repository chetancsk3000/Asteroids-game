using UnityEngine;

/// <summary>
/// The Obstacle class is a base class for all obstacles in the game, such as meteorites.
/// It contains properties like health and size, and methods for handling collision and destruction.
/// </summary>
public class Obstacle : MonoBehaviour
{
    public int health = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("Hitt.");
            TakeDamage(collision.GetComponent<Bullet>().damage);
        }
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.PlayerHit();
            DestroyObstacle();
        }
        // if(!(collision.CompareTag("Enemy") && collision.CompareTag("Bullet")))
            // DestroyObstacle();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            DestroyObstacle();
        }
    }

    private void DestroyObstacle()
    {

        Destroy(gameObject); // Destroy
    }
}
