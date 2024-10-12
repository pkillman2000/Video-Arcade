using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Whatever object this is attached to will self-destruct after a set
 * period of time.  It was written for the teleport particle effect which
 * is instantiated as a child of the player.  After the effect has played,
 * it is no longer needed and after several teleports, it would be possible
 * for the player to have several unneeded children.
 */
namespace Platformer
{
    public class SelfDestruct : MonoBehaviour
    {
        [SerializeField]
        private float _selfDestructTime = 3.0f;
        void Start()
        {
            Destroy(gameObject, _selfDestructTime);
        }
    }
}