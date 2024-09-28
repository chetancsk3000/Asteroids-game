using UnityEngine;

/// <summary>
/// The PlayerController class handles player movement and shooting.
/// It reads input from the user and moves the player accordingly using Rigidbody.
/// It also uses the BulletPool to manage shooting.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public BulletPool bulletPool;
    public Transform attackPoint;

    private Rigidbody2D rb;

    public Vector2 minBounds; // Minimum bounds for clamping
    public Vector2 maxBounds; // Maximum bounds for clamping

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public float acceleration = 5f;
    public float deceleration = 5f;
    private Vector2 currentVelocity = Vector2.zero;

    public void HandleMovement(float moveX, float moveY)
    {
        Vector2 input = new Vector2(moveX, moveY).normalized;
        currentVelocity = Vector2.Lerp(currentVelocity, input * moveSpeed, acceleration * Time.deltaTime);

        if (input.magnitude == 0) // If no input, decelerate to stop
        {
            currentVelocity = Vector2.Lerp(currentVelocity, Vector2.zero, deceleration * Time.deltaTime);
        }

        Vector2 newPosition = rb.position + currentVelocity * Time.deltaTime;

        // Clamp the player's position within the min and max bounds
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        rb.MovePosition(newPosition);
    }

    public void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("fired");
            bulletPool.SpawnBullet(attackPoint.position, transform.up);
        }
    }
}