using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingFloor : MonoBehaviour
{
    private Material _material;
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    [SerializeField]
    [Range(0, 1)]
    private float _alpha = 1f;
    private Color _startingColor;
    private Color _currentColor;
    [SerializeField]
    private float _cycleSpeed = .3f;

    void Start()
    {
        _material = GetComponent<Renderer>().material;
        if( _material == null )
        {
            Debug.Log("Material is Null!");
        }

        _rigidbody = GetComponent<Rigidbody>();
        if( _rigidbody == null )
        {
            Debug.LogError("Rigidbody is Null!");
        }

        _boxCollider = GetComponent<BoxCollider>();
        if( _boxCollider == null )
        {
            Debug.LogError("Box Collider is Null!");
        }

        _startingColor = _material.color;
    }


    void Update()
    {
        OscillateFloorTransparency();
    }

    private void OscillateFloorTransparency()
    {
        _alpha = Mathf.PingPong(_cycleSpeed * Time.time, 1);

        _currentColor = new Color(_startingColor.r, _startingColor.g, _startingColor.b, _alpha);
        _material.color = _currentColor;

        if (_alpha < .2f) // Can fall through floor
        {
            _rigidbody.detectCollisions = false;
            _rigidbody.isKinematic = false;
            _boxCollider.enabled = false;
        }
        else // Cannot fall through floor
        {
            _rigidbody.detectCollisions = true;
            _rigidbody.isKinematic = true;
            _boxCollider.enabled = true;
        }
    }
}
