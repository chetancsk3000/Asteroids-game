using UnityEngine;

/// <summary>
/// The Meteorite class inherits from the Obstacle class and adds specific behavior for meteorites,
/// such as movement and size variability.
/// </summary>
public class Meteorite : Obstacle
{
    public float moveSpeed = 2f;

    void Update()
    {
        // Move meteorite down the screen
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        // Deactivate meteorite when it goes off screen
        Destroy(gameObject);
    }
}
