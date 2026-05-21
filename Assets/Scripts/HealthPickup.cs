using Controllers;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healAmount = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthController playerHealth = collision.GetComponent<HealthController>();
            if (playerHealth != null)
            {
                playerHealth.RecoverHealth(healAmount);
                Destroy(gameObject);
            }
        }
    }
}