using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField]
        private GameObject _missile;
        [SerializeField]
        private Vector3 _missilePosition;
        [SerializeField]
        private int _maxNumberOfMissiles = 10;
        private int _currentNumberOfMissiles;
        private bool _canFire = true;
        [SerializeField]
        private float _fireRate = 1f;

        // Inputs
        private InputActions _inputActions;

        void Start()
        {
            _currentNumberOfMissiles = _maxNumberOfMissiles;

            // New Input System
            _inputActions = new InputActions();
            if (_inputActions == null)
            {
                Debug.LogError("Input Actions is Null!");
            }
            else
            {
                _inputActions.Land.Enable();
            }

            // Fire
            _inputActions.Land.Fire.performed += Fire_performed;
        }

        private void Fire_performed(InputAction.CallbackContext obj)
        {
            // Must have ammo and cool-down
            if (_currentNumberOfMissiles > 0 && _canFire)
            {
                GameObject newMissile = Instantiate(_missile, this.transform.position + _missilePosition, this.transform.rotation);
                _currentNumberOfMissiles--;
                StartCoroutine(FireRate());
            }
        }

        // Used by ammo power-up
        public void ReloadMissiles(int numberOfMissiles)
        {
            _currentNumberOfMissiles += numberOfMissiles;
            if(_currentNumberOfMissiles > _maxNumberOfMissiles)
            {
                _currentNumberOfMissiles = _maxNumberOfMissiles;
            }
        }

        // Limits the fire rate
        IEnumerator FireRate()
        {
            _canFire = false;
            yield return new WaitForSeconds(_fireRate);
            _canFire = true;
        }
    }
}
