using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This will teleport any game object that is passed in.  It has
 * particle effects to show the teleport sequence.
*/

namespace Platformer
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _teleportDestination;
        [SerializeField]
        private GameObject _teleportParticleEffect;

        // Set this to half the length of the teleport particle effect
        [SerializeField]
        private float _teleportDelay = 1.0f;

        public void Activate(GameObject _teleportObject)
        {
            /*
             * Make the particle effect a child of the teleport object.  This way,
             * if the object is moving, (Player), the effect will follow.
            */

            GameObject childObject = Instantiate(_teleportParticleEffect, _teleportObject.transform);
            StartCoroutine(Teleport(_teleportObject));
        }

        /*
         * Teleport Object is actually moved after a certain amount of time.  This is
         * usually half of the particle effect lifetime as set by _teleportDelay.
        */
        IEnumerator Teleport(GameObject _teleportObject)
        {
            yield return new WaitForSeconds(_teleportDelay);
            _teleportObject.transform.position = _teleportDestination;
        }
    }
}