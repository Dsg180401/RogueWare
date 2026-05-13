
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    public GameObject endGameObject;
    public UnityEvent onAllEnemiesDefeated;
    private int _enemyCount = 0;
    public BoxCollider2D triggerBox;
    private bool _completed = false;
    

    private void Start()
    {
        if (triggerBox != null)
            triggerBox.enabled = false;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterEnemy()
    {
        _enemyCount++;

        Debug.Log("Enemy Registered. Total: " + _enemyCount);
    }

    public void EnemyKilled()
    {
        if (_completed)
            return;

        _enemyCount--;

        Debug.Log("Enemy Killed. Remaining: " + _enemyCount);

        if (_enemyCount <= 0)
        {
            _completed = true;

            Debug.Log("ALL ENEMIES DEFEATED!");

            if (endGameObject != null)
            {
                endGameObject.SetActive(true);
            }

            onAllEnemiesDefeated?.Invoke();
            EnableTrigger();
        }
    }
    private void EnableTrigger()
    {
        if (triggerBox != null && !triggerBox.enabled)
        {
            triggerBox.isTrigger = true; // Ensure it's a trigger
            triggerBox.enabled = true;   // Activate it
            Debug.Log("Trigger box enabled!");
        }
    }

    // Example trigger event
    private void OnTriggerEnter(Collider other) // Use OnTriggerEnter2D for 2D
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger!");
        }
    }
}
