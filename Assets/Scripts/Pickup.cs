/*
 * Pickup script handles the interaction between the MainCamera and a cube, incrementing a counter and destroying the cube.
 */

using UnityEngine;

public class Pickup : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        // Get the GameManager component from the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            // Increment the cube count in the GameManager
            gameManager.IncrementCubeCount();
            
            // Increment the cube counter
            CubeCounter.instance.IncrementCounter();

            // Destroy the cube
            Destroy(gameObject);
        }
    }
}
