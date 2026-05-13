using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 3f;

    private Transform player;
    private bool isActivated = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Register enemy with manager
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.RegisterEnemy();
        }
    }

    void Update()
    {
        if (!isActivated)
            return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }

    public void ActivateEnemy()
    {
        isActivated = true;
    }

    private void OnDestroy()
    {
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.EnemyKilled();
        }
    }
}