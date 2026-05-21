using System;
using Controllers;
using UnityEngine;

namespace Obstacles
{
    public class DealDamageOnTrigger : MonoBehaviour
    {
        public float damageToTake;
        public bool onlyHitsPlayer;
        public bool onlyHitsEnemy;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player") && !other.CompareTag("Enemy")) return;
            if (onlyHitsPlayer && !other.CompareTag("Player")) return;
            if (onlyHitsEnemy && !other.CompareTag("Enemy")) return;
            
            other.GetComponentInParent<HealthController>().TakeDamage(damageToTake);
        }
    }
}
