using Controllers;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healAmount = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player touched the pickup
        if (collision.CompareTag("Player"))
        {
            // Get the player's HealthController
            HealthController playerHealth = collision.GetComponent<HealthController>();

            // Make sure it exists
            if (playerHealth != null)
            {
                // Heal the player
                playerHealth.RecoverHealth(healAmount);

                // Destroy the pickup
                Destroy(gameObject);
            }
        }
    }
}