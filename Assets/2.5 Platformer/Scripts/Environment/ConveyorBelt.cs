using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class ConveyorBelt : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 500f;
        [SerializeField]
        private Vector3 _direction = new Vector3(1, 0, 0);
        public List<GameObject> _objectsOnBelt;

        void Update()
        {
            MoveObjectsOnBelt();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _objectsOnBelt.Add(collision.gameObject);
        }

        private void OnCollisionExit(Collision collision)
        {
            _objectsOnBelt.Remove(collision.gameObject);
        }

        private void MoveObjectsOnBelt()
        {
            for (int i = 0; i <= _objectsOnBelt.Count - 1; i++)
            {
                _objectsOnBelt[i].GetComponent<Rigidbody>().velocity = _direction * _speed * Time.deltaTime;
            }
        }
    }
}