using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Console : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private SetObjectColor _statusLight;

        private bool _consoleActive = false;

        public void ActivateConsole()
        {
            _consoleActive = true;
            _statusLight.SetColor(Color.green);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player" && _consoleActive)
            {
                _animator.SetBool("IsInactive", false);
            }
        }
    }
}