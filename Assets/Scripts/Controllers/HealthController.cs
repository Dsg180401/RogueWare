using MoreMountains.Feedbacks;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Controllers
{
    public class HealthController : MonoBehaviour
    {
        public float health;
        [HideInInspector] public float maxHealth;
        
        public float invulnTime;
        private float _timer;
        private bool _isInvuln;
        
        private SpriteRenderer _sprite;
        
        private GameObject _damageNumUI;
        
        private PlayerController _playerController;
        public PlayerHealthUI healthUI;
        private MMF_Player _mmf;
        public UnityEvent onDeath;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _damageNumUI = transform.GetChild(1).gameObject;
            
            if (gameObject.CompareTag("Player"))
            {
                _mmf = GetComponent<MMF_Player>();
                _playerController = GetComponent<PlayerController>();
            }
            
            maxHealth = health;
        }
        
        private void Update()
        {
            if (!_isInvuln) return;
            _timer += Time.deltaTime;
            if (!(_timer >= invulnTime)) return;
            _isInvuln = false;
            _sprite.color = Color.white;
        }
        
        public void TakeDamage(float damageToTake)
        {
            if (_isInvuln) return;
            if (IsPlayer() && PlayerInputInvulnerability()) return;
            
            _sprite.color = Color.grey;
            if (health - damageToTake <= 0) {Die();}
            else {health -= damageToTake;}
            
            _damageNumUI.GetComponent<TMP_Text>().text = "-" + damageToTake;
            _damageNumUI.GetComponent<MMF_Player>().PlayFeedbacks();
            
            _isInvuln = true;
            _timer = 0;
            
            if (IsPlayer())
            {
                healthUI.UpdateOnDamage();
                TriggerShake();
            }
        }

        public void RecoverHealth(float healthToRecover)
        {
            if (health + healthToRecover >= maxHealth)
            {
                health = maxHealth;
            }
            else
            {
                health += healthToRecover;
            }
            
            if (IsPlayer())
            {
                healthUI.UpdateOnDamage();
            }
        }
        
        private void Die()
        {
            onDeath.Invoke();
        }

        public void DestroyGameObject()
        {
            Destroy(gameObject);
        }
        
        
        private bool IsPlayer()
        {
            return gameObject.CompareTag("Player");
        }
        
        private void TriggerShake()
        {
            _mmf.PlayFeedbacks();
        }
        
        private bool PlayerInputInvulnerability()
        {
            return _playerController.isJumping;
        }
    }
}
