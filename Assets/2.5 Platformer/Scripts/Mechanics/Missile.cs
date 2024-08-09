using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;

namespace Platformer
{
    public class Missile : MonoBehaviour
    {
        [SerializeField]
        private float _missileSpeed = 10f;
        [SerializeField]
        private int _missileDamage = 5;
        [SerializeField]
        private float _missileLifetime = 1f;

        private Rigidbody _rigidbody;
        private PlayerMovement _playerMovement;
        private bool _playerIsFlipped;

        void Start()
        {
            Destroy(this.gameObject, _missileLifetime);

            _playerMovement = FindObjectOfType<PlayerMovement>();
            if( _playerMovement == null )
            {
                Debug.LogError("Player Movement is Null!");
            }
            else
            {
                _playerIsFlipped = _playerMovement.GetIsFlipped();
            }
        }

        void Update()
        {
            MoveMissile();
        }

        private void MoveMissile()
        {
            if (_playerIsFlipped)
            {
                transform.position += Vector3.left * _missileSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.right * _missileSpeed * Time.deltaTime;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.RemoveHealth(_missileDamage);
            }
            Debug.Log("Missile Destroyed");
            Destroy(this.gameObject);
        }
    }
}