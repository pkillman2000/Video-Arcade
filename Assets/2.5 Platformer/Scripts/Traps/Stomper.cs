using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer
{
    public class Stomper : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1f;
        [SerializeField]
        private float _minimumHeight = 1f;
        [SerializeField]
        private float _maximumHeight = 5f;
        [SerializeField]
        private int _damage = 20;

        // Starting position for the Lerp
        private float t = 1f;

        private bool _canMove = true;

        void Update()
        {
            if (_canMove)
            {
                Oscillate();
            }
        }

        private void Oscillate()
        {
            // .. and increase the t interpolater
            t += _speed * Time.deltaTime;

            // now check if the interpolator has reached 1.0
            // and swap maximum and minimum so game object moves
            // in the opposite direction.
            if (t > 1.0f)
            {
                float temp = _maximumHeight;
                _maximumHeight = _minimumHeight;
                _minimumHeight = temp;
                t = 0.0f;
            }

            MoveStomper();
        }

        private void MoveStomper()
        {
            // animate the position of the game object...
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Lerp(_minimumHeight, _maximumHeight, t), this.transform.localPosition.z);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                // Player takes damage
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                playerHealth.RemoveHealth(_damage);

                PauseStomper();
            }
            else if(collision.gameObject.tag == "Enemy")
            {
                EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.RemoveHealth(_damage);

                PauseStomper();
            }
        }

        private void PauseStomper()
        {
            // Stop Stomper
            _canMove = false;
            StartCoroutine(RestartStomper());

            // Ease ceiling back up a little bit;
            t -= .1f;
            MoveStomper();

        }
        IEnumerator RestartStomper()
        {
            yield return new WaitForSeconds(5f);
            _canMove = true;
        }
    }
}
