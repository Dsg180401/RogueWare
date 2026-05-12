using UnityEngine;

public class WeaponFollowMouse : MonoBehaviour
{
    public Transform player;     // Player transform
    public float radius = 1.5f; // Distance from player

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Get mouse position in world space
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Direction from player to mouse
        Vector3 direction = (mousePos - player.position).normalized;

        // Position weapon around player
        transform.position = player.position + direction * radius;

        // Rotate weapon to face mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Optional: Flip weapon sprite correctly
        Vector3 localScale = transform.localScale;

        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }

        transform.localScale = localScale;
    }
}