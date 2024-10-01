using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class RespawnPoint : MonoBehaviour
    {
        private Vector3 _respawnPoint;
        void Start()
        {
            _respawnPoint = new Vector3(this.transform.position.x, this.transform.position.y + 1.06f, this.transform.position.z);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerMovement _playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
                if (_playerMovement == null)
                {
                    Debug.LogError("Player Movement is Null!");
                }
                _playerMovement.SetRespawnPoint(_respawnPoint);
            }
        }
    }
}
