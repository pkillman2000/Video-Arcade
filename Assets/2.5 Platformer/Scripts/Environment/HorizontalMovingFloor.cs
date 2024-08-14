using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovingFloor : MonoBehaviour
{
    [SerializeField]
    private float _maxX;
    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private float _pauseDuration = 1f;
    private float _startingX;
    private float _currentX;

    private void Start()
    {
        _startingX = this.transform.position.x;
    }
    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        _currentX = Mathf.PingPong(_speed * Time.time, _maxX);
        transform.position = new Vector3(_currentX + _startingX, this.transform.position.y, this.transform.position.z);
    }
}
