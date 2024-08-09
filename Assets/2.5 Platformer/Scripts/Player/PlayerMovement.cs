using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private GameObject _playerBody;
        [SerializeField]
        private float _walkSpeed = 5f;
        [SerializeField]
        private float _runSpeed = 10f;
        [SerializeField]
        private float _jumpSpeed = 5f;
        [SerializeField]
        private float _climbSpeed = 5f;
        [SerializeField]
        private Vector3 _respawnPoint;

        // Inputs
        private InputActions _inputActions;

        // LAND
            // Walking
            private bool _walkingInput = false;
            private float _inputWalkingSpeed = 0f;
            public bool _isTouchingFloor = true;
            // Climbing
            private bool _climbingInput = false;
            private float _inputClimbingSpeed = 0f;
            private bool _isTouchingLadder = false;
            // Running
            private bool _isRunning = false;

        // AIR
        // WATER

        private Rigidbody _rigidBody;
        private bool _playerAlive = true;
        private bool _isFlipped = false;

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

            // Walk
            _inputActions.Land.Walk.started += StartWalking;
            _inputActions.Land.Walk.canceled += StopWalking;

            // Jump
            _inputActions.Land.Jump.performed += Jump;

            // Climb
            _inputActions.Land.Climb.started += StartClimbing;
            _inputActions.Land.Climb.canceled += StopClimbing;

            // Run
            _inputActions.Land.Run.started += StartRunning;
            _inputActions.Land.Run.canceled += Run_canceled;

            _rigidBody = GetComponent<Rigidbody>();
            if (_rigidBody == null)
            {
                Debug.LogError("Rigidbody is Null!");
            }
        }


        void Update()
        {
            Walk();
            Climb();
        }

        // Check to see what player is touching
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Floor")
            {
                _isTouchingFloor = true;
            }

            if (collision.gameObject.tag == "Ladder")
            {
                _isTouchingLadder = true;
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "Floor")
            {
                _isTouchingFloor = true;
            }

            if (collision.gameObject.tag == "Ladder")
            {
                _isTouchingLadder = true;
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Floor")
            {
                _isTouchingFloor = false;
            }

            if (collision.gameObject.tag == "Ladder")
            {
                _isTouchingLadder = false;
            }
        }

        // Walking
        private void StartWalking(InputAction.CallbackContext obj)
        {
            _walkingInput = true;
            if (obj.ReadValue<float>() > 0)
            {
                _inputWalkingSpeed = 1f;
                // Flip player to right
                _playerBody.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                _isFlipped = false;
            }
            else if (obj.ReadValue<float>() < 0)
            {
                _inputWalkingSpeed = -1f;
                // Flip player to left
                _playerBody.transform.eulerAngles = new Vector3(0f, 180f, 0f);
                _isFlipped = true;
            }
            else
            {
                _inputWalkingSpeed = 0f;
            }
        }

        private void StopWalking(InputAction.CallbackContext obj)
        {
            _walkingInput = false;
        }

        private void Walk()
        {
            /*
                Uncomment if you wish to only allow the player horizontal
                movement control when touching the ground.  When it is 
                commented out, player can change direction in mid-air or jump
                off of the ladder.

                TODO: Make this a checkbox option where the level designer or player can change it.
            */
            //if (_isTouchingFloor)
            //{
            if (_walkingInput)
            {
                if (_isRunning)
                {
                    Vector2 playerVelocity = new Vector2(_inputWalkingSpeed * _runSpeed, _rigidBody.velocity.y);
                    _rigidBody.velocity = playerVelocity;
                }
                else
                {
                    Vector2 playerVelocity = new Vector2(_inputWalkingSpeed * _walkSpeed, _rigidBody.velocity.y);
                    _rigidBody.velocity = playerVelocity;
                }
            }
            else
            {
                _inputWalkingSpeed = 0;
            }
            //}    
        }

        public bool GetIsFlipped()
        {
            return _isFlipped;
        }

        // Jumping
        private void Jump(InputAction.CallbackContext obj)
        {
            if (_isTouchingFloor)
            {
                Vector3 jumpVelocityToAdd = new Vector3(0f, _jumpSpeed, 0f);
                _rigidBody.velocity += jumpVelocityToAdd;
            }
        }

        // Climbing
        private void StartClimbing(InputAction.CallbackContext obj)
        {
            if (_isTouchingLadder)
            {
                _climbingInput = true;
                // Allows player to stop on the ladder
                if (obj.ReadValue<float>() > 0)
                {
                    _inputClimbingSpeed = 1f;
                }
                else if (obj.ReadValue<float>() < 0)
                {
                    _inputClimbingSpeed = -1f;
                }
                else
                {
                    _inputClimbingSpeed = 0f;
                }
            }
        }

        private void StopClimbing(InputAction.CallbackContext obj)
        {
            _climbingInput = false;
            _inputClimbingSpeed = 0f;
        }

        private void Climb()
        {
            if (_isTouchingLadder)
            {
                if (_climbingInput)
                {
                    _rigidBody.useGravity = false;
                    Vector2 playerVelocity = new Vector2(_rigidBody.velocity.x, _inputClimbingSpeed * _climbSpeed);
                    _rigidBody.velocity = playerVelocity;
                }
            }
            else
            {
                Vector2 playerVelocity = new Vector2(_rigidBody.velocity.x, 0);
                _rigidBody.useGravity = true;
            }
        }

        // Running
        private void StartRunning(InputAction.CallbackContext obj)
        {
            _isRunning = true;
        }

        private void Run_canceled(InputAction.CallbackContext obj)
        {
            _isRunning = false;
        }

        public void SetRespawnPoint(Vector3 respawnPoint)
        {
            _respawnPoint = respawnPoint;
        }

        public void Respawn()
        {
            this.transform.position = _respawnPoint;
        }

    }
}
