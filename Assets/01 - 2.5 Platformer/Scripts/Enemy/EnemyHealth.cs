using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField]
        private int _maxHealth = 20;
        public int _currentHealth;

        void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void RemoveHealth(int health)
        {
            _currentHealth -= health;
            if(_currentHealth <= 0 )
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(this.gameObject);
        }
    }
}
