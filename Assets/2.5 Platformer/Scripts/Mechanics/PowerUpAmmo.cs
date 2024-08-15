using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PowerUpAmmo : MonoBehaviour
    {
        [SerializeField]
        private int _ammo = 10;
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
                PlayerCombat playerCombat = collision.gameObject.GetComponent<PlayerCombat>();
                playerCombat.ReloadMissiles(_ammo);
                Destroy(this.gameObject);
            }
        }

        private void CycleLightIntensity()
        {
            _light.intensity = Mathf.PingPong(_cycleFrequency * Time.time, _maxIntensity);
        }
    }
}