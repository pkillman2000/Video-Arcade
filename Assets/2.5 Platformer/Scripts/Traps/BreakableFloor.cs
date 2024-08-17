using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class BreakableFloor : MonoBehaviour
    {
        private Rigidbody _rigidBody;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            if ( _rigidBody == null )
            {
                Debug.LogError("Rigidbody is Null!");
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                _rigidBody.isKinematic = false;
                _rigidBody.useGravity = true;
            }
        }
    }
}