using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This caused the material of the selected object to scroll vertically.
 * It was designed to display a scrolling screen on the console object.
 * On the sprite, set the texture type to 'Default' to make it display
 * properly.
*/
namespace Platformer
{
    public class ScrollBackground : MonoBehaviour
    {
        [SerializeField]
        private float _scrollSpeed = 0.1F;

        private Renderer _rend;

        void Start()
        {
            _rend = GetComponent<Renderer>();
            if (_rend == null)
            {
                Debug.LogError("Renderer is Null!");
            }
        }
        void Update()
        {
            float offset = Time.time * _scrollSpeed;
            _rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }
    }
}