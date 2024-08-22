using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PowerUpHealth : MonoBehaviour
    {
        [SerializeField]
        private int _health = 10;
        [SerializeField]
        private Light _light;
        private float _maxIntensity = 1.0f;
        [SerializeField]
        private float _cycleFrequency = 2.0f;
        private float _currentIntensity;

        private void Update()
        {
            CycleLightIntensity();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                playerHealth.AddHealth(_health);
                Destroy(this.gameObject);
            }
        }

        private void CycleLightIntensity()
        {
            _light.intensity = Mathf.PingPong(_cycleFrequency * Time.time, _maxIntensity);
        }
    }
}