using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 3f;

    private Transform player;
    private bool isActivated = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isActivated)
            return;

        // Move toward player
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
}