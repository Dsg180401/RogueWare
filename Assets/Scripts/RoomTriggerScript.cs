using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    private EnemyScript[] enemiesInRoom;

    void Start()
    {
        // Find all enemies inside this room
        enemiesInRoom = GetComponentsInParent<EnemyScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (EnemyScript enemy in enemiesInRoom)
            {
                enemy.ActivateEnemy();
            }

            // Optional: disable trigger after activation
            gameObject.SetActive(false);
        }
    }
}