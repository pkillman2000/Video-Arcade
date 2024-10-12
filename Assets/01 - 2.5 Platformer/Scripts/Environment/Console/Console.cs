using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

namespace Platformer
{
    public class Console : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator = null;
        [SerializeField] 
        private Teleporter _teleporter = null;
        [SerializeField]
        private SetObjectColor _statusLight;

        private bool _consoleActive = false;
        private string _gameTag;

        public void ActivateConsole()
        {
            _consoleActive = true;
            _statusLight.SetColor(Color.green);
            _gameTag = this.gameObject.tag;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player" && _consoleActive)
            {
                /*
                 * Depending upon what this script is attached to, it will act
                 * in different ways.  
                 * Animated is meant for objects that use 
                 * an animation to perform an action such as doors/gates/etc...
                 * Teleport will cause the Activate method to be called.
                 * Platform will cause the platform to begin or stop movement
                 * as necessary
                */
                switch (_gameTag)
                {
                    case "Animated":
                        _animator.SetBool("IsInactive", false);
                        Debug.Log("Animated Active");
                        break;
                    case "Teleport":
                        _teleporter.Activate(other.gameObject);
                        break;
                    case "Platform":
                        break;
                }
            }
        }
    }
}