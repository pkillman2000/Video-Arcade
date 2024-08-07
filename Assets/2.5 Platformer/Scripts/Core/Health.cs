using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Movement;

namespace Platformer.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int _maxHealth = 100;
        [SerializeField]
        private int _currentHealth = 100;
        [SerializeField]
        private int _numberOfLives = 5;

        private PlayerMovement _playerMovement;

        private void Start()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            if (_playerMovement == null)
            {
                Debug.LogError("Player Movement is Null!");
            }
        }

        // Health
        public void AddHealth(int health)
        {
            _currentHealth += health;
            if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }

        public void RemoveHealth(int health)
        {
            _currentHealth -= health;
            if (_currentHealth < 0)
            {
                Die();
            }
        }

        public int GetHealth()
        {
            return _currentHealth; 
        }

        // Lives
        public void AddLife()
        {
            _numberOfLives++;
        }

        public void RemoveLife()
        {
            _numberOfLives--;
            if (_numberOfLives < 1)
            {
                Debug.Log("Game Over!");
                // TODO: Game Over!
            }
        }

        private void Die()
        {
            RemoveLife();
            _currentHealth = _maxHealth;
            _playerMovement.Respawn();
        }
    }
}
