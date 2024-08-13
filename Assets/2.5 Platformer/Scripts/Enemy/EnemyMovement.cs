using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class EnemyMovement : MonoBehaviour
    {
        // Enemy Stats
        [SerializeField]
        private float _movementSpeed = 5;
        [SerializeField]
        private int _maxHealth = 20;
        private int _currentHealth;
        // Detection
        [SerializeField]
        private int _detectionDistanceX = 10;
        [SerializeField]
        private int _detectionDistanceY = 1;
        // Patrolling
        [SerializeField]
        private Vector3[] _wayPoints;
        private int _currentWaypoint = 0;
        [SerializeField]
        private float _wayPointTolerance = .1f;
        // Combat
        [SerializeField]
        private int _combatDistanceX = 3;
        [SerializeField]
        private int _combatDistanceY = 1;
        [SerializeField]
        private int _enemyDamage = 5;
        [SerializeField]
        private float _damageRate = 1f;
        private bool _canDamage = true;
        // State
        private enum State
        {
            Patrolling,
            Chasing,
            Attacking
        }
        private State _enemyState = State.Patrolling;
        // Player
        private PlayerHealth _playerHealth;
        private Vector2 _playerRange;

        void Start()
        {
            _playerHealth = FindObjectOfType<PlayerHealth>();
            if (_playerHealth == null)
            {
                Debug.LogError("Player Health is Null!");
            }
        }


        void Update()
        {
            CalculatePlayerState();
        }

        private void CalculatePlayerState()
        {
            // Calculate range to Player
            _playerRange = new Vector2(Mathf.Abs(_playerHealth.transform.position.x - this.transform.position.x),
                Mathf.Abs(_playerHealth.transform.position.y - this.transform.position.y));

            if ((_playerRange.x < _combatDistanceX) && (_playerRange.y < _combatDistanceY))
            {
                _enemyState = State.Attacking;
                Attack();
            }
            else if ((_playerRange.x < _detectionDistanceX) && (_playerRange.y < _detectionDistanceY))
            {
                _enemyState = State.Chasing;
                Chase();
            }
            else
            {
                _enemyState = State.Patrolling;
                Patrol();
            }
        }

        // Patrolling
        private void Patrol()
        {
            // Check to see if near waypoint
            if (Vector3.Distance(_wayPoints[_currentWaypoint], this.transform.position) < _wayPointTolerance)
            {
                _currentWaypoint++;
                if (_currentWaypoint >= _wayPoints.Length)
                { 
                    _currentWaypoint = 0; 
                }
            }
            MoveEnemy(_wayPoints[_currentWaypoint]);
        }

        // Chasing
        private void Chase()
        {
            MoveEnemy(_playerHealth.transform.position);
        }

        // Attacking
        private void Attack()
        {
            MoveEnemy(_playerHealth.transform.position);            
            if (_canDamage)
            {
                _playerHealth.RemoveHealth(_enemyDamage);
                StartCoroutine(InflictDamage());
            }
        }

        IEnumerator InflictDamage()
        {
            _canDamage = false;
            yield return new WaitForSeconds(_damageRate);
            _canDamage = true;
        }

        // Enemy movement
        private void MoveEnemy(Vector3 target)
        {
            float speed = _movementSpeed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed);
        }
    }
}
