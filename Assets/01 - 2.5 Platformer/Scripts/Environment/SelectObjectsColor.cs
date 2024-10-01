using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Use this to set the color of all objects associated with a console,
 * the initiator (keycard, key...), console, and action object (door, teleporter,
 * trap...)
 * Each of the objects above must have the SetObjectColor script attached.
 * Execution order is set to 300 so that it executes AFTER the SetObjectColor script.
*/
namespace Platformer
{
    [DefaultExecutionOrder(300)]
    public class SelectObjectsColor : MonoBehaviour
    {
        [SerializeField]
        private Color _color;

        [SerializeField]
        [Tooltip("Keycard, Key, etc...")]
        private SetObjectColor _initiator;
        [SerializeField]
        private SetObjectColor _console;
        [SerializeField]
        [Tooltip("Door, Teleport Pad, Trap, etc...")]
        private SetObjectColor _actionObject;

        void Start()
        {
            _initiator.SetColor(_color);
            _console.SetColor(_color);
            _actionObject.SetColor(_color);
        }
    }
}