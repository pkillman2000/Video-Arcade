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

        // Inputs
        private InputActions _inputActions;

        void Start()
        {
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

        void Update()
        {
        }

        private void Fire_performed(InputAction.CallbackContext obj)
        {
            GameObject newMissile = Instantiate(_missile, this.transform.position + _missilePosition, this.transform.rotation);
            //newMissile.transform.right = transform.right.normalized;
        }

    }
}
