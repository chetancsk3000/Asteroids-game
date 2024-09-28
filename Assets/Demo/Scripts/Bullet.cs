using UnityEngine;

/// <summary>
/// The Bullet class handles the movement and behavior of bullets.
/// It also manages collision detection and deactivates itself instead of being destroyed,
/// as part of the object pooling system.
/// </summary>
public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collision logic with meteors or other objects
        if (collision.CompareTag("Enemy"))
        {
            // Reduce enemy health or score
            GameManager.Instance.UpdateScore(damage);
        }
        // Deactivate bullet instead of destroying it
        gameObject.SetActive(false);
    }

    public void CallDestroy()
    {
        Invoke("Destroy", 2f);
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
