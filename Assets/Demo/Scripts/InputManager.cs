using UnityEngine;

/// <summary>
/// The InputManager class centralizes all input handling for the player.
/// It collects input data from the user and relays it to the PlayerController for movement and shooting.
/// </summary>
public class InputManager : MonoBehaviour
{
    public PlayerController playerController;

    public void awake(){

    }
    public void start(){

    }
    public void Update(){

    }

    void Update()
    {
        // Forward movement input to the player controller
        playerController.HandleMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Forward shooting input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.HandleShooting();
        }
    }
}
