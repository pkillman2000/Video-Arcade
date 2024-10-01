using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Attach this script to any object that you wish to be able to change
 * the color of via another script.
 * This is designed to be used by the SelectObjectsColor script, but can
 * be called via any script in the Platformer namespace.
 * It is recommended that you set the Execution Order of whatever script is
 * calling it to a number larger than 200.
*/
namespace Platformer
{
    [DefaultExecutionOrder(200)]
    public class SetObjectColor : MonoBehaviour
    {
        private Renderer _renderer;

        private void Start()
        {
            _renderer = this.GetComponent<Renderer>();
            if( _renderer == null )
            {
                Debug.LogError("Renderer is Null!");
            }
        }

        public void SetColor(Color color)
        {
            _renderer.material.SetColor("_Color", color);
        }
    }
}