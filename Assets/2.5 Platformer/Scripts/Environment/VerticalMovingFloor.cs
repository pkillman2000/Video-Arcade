using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingFloor : MonoBehaviour
{
    [SerializeField]
    private float _maxY;
    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private float _pauseDuration = 1f;
    private float _startingY;
    private float _currentY;

    private void Start()
    {
        _startingY = this.transform.position.y;
    }
    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        _currentY = Mathf.PingPong(_speed * Time.time, _maxY);
        transform.position = new Vector3(this.transform.position.x, _currentY + _startingY, this.transform.position.z);
    }
}
