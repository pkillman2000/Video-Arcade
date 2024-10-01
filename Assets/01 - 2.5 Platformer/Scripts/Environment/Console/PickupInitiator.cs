using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * When the player enters the trigger, it activates the appropriate console and
 * then self-destructs.
*/

namespace Platformer
{
    public class PickupInitiator : MonoBehaviour
    {
        [SerializeField]
        private Console _console;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                _console.ActivateConsole();
                Destroy(this.gameObject);
            }
        }
    }
}