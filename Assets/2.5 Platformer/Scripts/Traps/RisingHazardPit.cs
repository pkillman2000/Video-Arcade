using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is used for all of the rising
 * hazard pit traps - lava, water, spikes...
 * 
 * Scale this object to cover the area that 
 * will be the hazard (probably just X and Z axis).  
 * Enter the current scale 
 * of this object into _cubeX, Y, and Z.
 * Fill Speed is how fast it rises per second.
 * Fill Depth is the Y axis total.
 * Damage per Second is how much damage the player
 * will take every second.
 */
namespace Platformer
{
    public class RisingHazardPit : MonoBehaviour
    {
        [SerializeField]
        private float _fillSpeed = .1f;
        [SerializeField]
        private float _fillDepth = 2.5f;
        [SerializeField]
        private int _damagePerSecond = 20;

        /*
         * As the Y scale increases, the Y position
         * has to increase by half of the scale to
         * keep the cube in the area.
        */
        private float _currentY;
        private bool _isActive = true;
        private Mesh _mesh;
        private float _xPosition;
        private float _yPosition;
        private float _zPosition;
        
        // Enter the current size of the lava cube
        [SerializeField]
        private float _cubeX = 4;
        [SerializeField]
        private float _cubeY = 0.01f;
        [SerializeField]
        private float _cubeZ = 4;

        private PlayerHealth _playerHealth;
        private bool _playerTakeDamage = false;

        void Start()
        {
            _currentY = this.transform.position.y;
            _mesh = GetComponent<MeshFilter>().sharedMesh;
            if(_mesh == null)
            {
                Debug.LogError("Mesh is Null!");
            }
            _xPosition = this.transform.position.x;
            _yPosition = this.transform.position.y;
            _zPosition = this.transform.position.z;
        }


        void Update()
        {
            if(_isActive)
            {
                RaiseLava();
            }
        }

        private void RaiseLava()
        {
            _cubeY += (_fillSpeed * Time.deltaTime);

            if (_cubeY <= _fillDepth)
            {
                transform.localScale = new Vector3(_cubeX, _cubeY, _cubeZ);
                _yPosition = _cubeY / 2;
                transform.position = new Vector3(_xPosition, _yPosition, _zPosition);
            }
            else
            {
                _isActive = false;
            }

            if (_playerTakeDamage)
            {
                CalculateDamage();
            }
        }

        private void OnTriggerEnter(Collider trigger)
        {
            if(trigger.gameObject.tag == "Player")
            {
                _playerHealth = trigger.gameObject.GetComponent<PlayerHealth>();
                if(_playerHealth == null)
                {
                    Debug.LogError("Player Health is Null!");
                }
                _playerTakeDamage = true;
            }
        }

        private void OnTriggerExit(Collider trigger)
        {
            if (trigger.gameObject.tag == "Player")
            {
                Debug.Log("Trigger Exited");

                _playerTakeDamage = false;
                _playerHealth = null;
            }
        }

        private void CalculateDamage()
        {
            // Rewrite to use a 1 second timer
            if (_playerHealth == null)
            {
                Debug.LogError("Player Health is Null!");
                _playerTakeDamage = false;
            }
            else
            {
                _playerHealth.RemoveHealth(_damagePerSecond);
            }
            _playerTakeDamage = false;
            Debug.Log("Calculate Damage");
            _playerTakeDamage = true;
        }
    }
}