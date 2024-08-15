using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script will move the platform between
 * multiple waypoints.  It can move in any direction
 * and will pause at each waypoint before moving to the
 * next.
*/
namespace Platformer
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 2f;
        [SerializeField]
        private float _pauseDuration = 1f;
        [SerializeField]
        private float _wayPointTolerance = .01f;
        [SerializeField]
        public Vector3[] _wayPoints;

        private int _currentWaypoint = 0;
        private bool _platformCanMove = true;

        void Update()
        {
            if (_platformCanMove)
            {
                Oscillate();
            }
        }

        private void Oscillate()
        {
            if (Vector3.Distance(_wayPoints[_currentWaypoint], this.transform.position) < _wayPointTolerance)
            {
                _currentWaypoint++;
                if (_currentWaypoint >= _wayPoints.Length)
                {
                    _currentWaypoint = 0;
                }
                StartCoroutine(PauseAtWaypoint());
            }
            MovePlatform();
        }

        private void MovePlatform()
        {
            float speed = _speed * Time.deltaTime;            
            this.transform.position = Vector3.MoveTowards(this.transform.position, _wayPoints[_currentWaypoint], speed);
        }

        IEnumerator PauseAtWaypoint()
        {
            _platformCanMove = false;
            yield return new WaitForSeconds(_pauseDuration);
            _platformCanMove = true;
        }
    }
}