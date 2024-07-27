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
    private bool _isWalking = false;
    private float _inputWalkingSpeed = 0f;


    private Rigidbody _rigidBody;
    private CapsuleCollider _bodyCollider;
    private float _defaultPlayerGravity;
    private bool _playerAlive = true;
    private bool _hasCollide = true;
    private bool _isTouchingGround = true;
    
    void Start()
    {
        _inputActions = new InputActions();
        if(_inputActions == null)
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

        _rigidBody = GetComponent<Rigidbody>();
        if(_rigidBody == null)
        {
            Debug.LogError("Rigidbody is Null!");
        }

        _bodyCollider = GetComponent<CapsuleCollider>();
        if(_bodyCollider == null)
        {
            Debug.LogError("Capsule Collider is Null!");
        }
    }

    void Update()
    {
        if(_isWalking)
        {
            Walk();
        }
    }


    // Walking
    private void StartWalking(InputAction.CallbackContext obj)
    {
        _isWalking = true;
        if(obj.ReadValue<float>() > 0)
        {
            _inputWalkingSpeed = 1f;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if(obj.ReadValue<float>() < 0)
        {
            _inputWalkingSpeed = -1f;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            _inputWalkingSpeed = 0f;
        }
    }

    private void StopWalking(InputAction.CallbackContext obj)
    {
        _isWalking = false;
    }

    private void Walk()
    {

        Vector2 playerVelocity = new Vector2(_inputWalkingSpeed * _runSpeed, _rigidBody.velocity.y);
        _rigidBody.velocity = playerVelocity;
    }

    // Jumping
    private void Jump(InputAction.CallbackContext obj)
    {

        if(_isTouchingGround)
        {
            Vector3 jumpVelocityToAdd = new Vector3(0f, _jumpSpeed, 0f);
            _rigidBody.velocity += jumpVelocityToAdd;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _isTouchingGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isTouchingGround = false;
        }
    }
}
