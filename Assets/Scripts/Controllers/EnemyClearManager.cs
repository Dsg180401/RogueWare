using UnityEngine;
using UnityEngine.Events;

public class EnemyClearManager : MonoBehaviour
{
    [Header("Object To Open When All Enemies Are Gone")]
    public GameObject endGameTrigger;

    [Header("Optional Event")] public UnityEvent onAllEnemiesDefeated;

    private bool _triggered = false;

    void Update()
    {
        // Prevent running more than once
        if (_triggered)
            return;

        // Find all remaining enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // If no enemies remain
        if (enemies.Length == 0)
        {
            _triggered = true;

            Debug.Log("All enemies defeated!");

            // Enable/open the end trigger
            if (endGameTrigger != null)
            {
                endGameTrigger.SetActive(true);
            }

            // Fire optional Unity event
            onAllEnemiesDefeated?.Invoke();
        }
    }
}