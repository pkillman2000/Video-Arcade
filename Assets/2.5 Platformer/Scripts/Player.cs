using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _runSpeed = 5f;
    [SerializeField]
    private float _jumpSpeed = 5f;
    [SerializeField]
    private float _climbSpeed = 5f;
    [SerializeField]
    private Vector3 _respawnPoint;

    // Inputs
    private InputActions _inputActions;
    // Walking
    private bool _walkingInput = false;
    private float _inputWalkingSpeed = 0f;
    public bool _isTouchingGround = true;
    // Climbing
    private bool _climbingInput = false;
    private float _inputClimbingSpeed = 0f;
    public bool _isTouchingLadder = false;

    private Rigidbody _rigidBody;
    private CapsuleCollider _bodyCollider;
    private float _defaultPlayerGravity;
    private bool _playerAlive = true;

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

        _rigidBody = GetComponent<Rigidbody>();
        if (_rigidBody == null)
        {
            Debug.LogError("Rigidbody is Null!");
        }

        _bodyCollider = GetComponent<CapsuleCollider>();
        if (_bodyCollider == null)
        {
            Debug.LogError("Capsule Collider is Null!");
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
        if (collision.gameObject.tag == "Ground")
        {
            _isTouchingGround = true;
        }

        if (collision.gameObject.tag == "Ladder")
        {
            _isTouchingLadder = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isTouchingGround = false;
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
        if(obj.ReadValue<float>() > 0)
        {
            _inputWalkingSpeed = 1f;
            // Flip player to right
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if(obj.ReadValue<float>() < 0)
        {
            _inputWalkingSpeed = -1f;
            // Flip player to left
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
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
        //if (_isTouchingGround)
        //{
            if (_walkingInput)
            {
                Vector2 playerVelocity = new Vector2(_inputWalkingSpeed * _runSpeed, _rigidBody.velocity.y);
                _rigidBody.velocity = playerVelocity;
            }
            else
            {
                _inputWalkingSpeed = 0;
            }
        //}    
    }

    // Jumping
    private void Jump(InputAction.CallbackContext obj)
    {
        if (_isTouchingGround)
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
}
