using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core
{
    /*
     * This script is placed on an empty object named Screen Fader.
     * I recommend making it a prefab so it's easy to put into every scene.
     * The Screen Fader object has a child image that is set to black.
     * The image is scaled to whatever size you need it to be.
     * To use the Screen Fader, place it in your canvas at the 
     * very bottom of the hierarchy.
    */

    public class SceneLoader : MonoBehaviour
    {
        // Attach a black image here.
        // Make sure the image is scaled appropriately.
        [SerializeField]
        private Image _fadeImage;

        // The larger the number, the faster the fade speed  (1/_fadeSpeed)
        // .5 = 2 seconds
        // 1 = 1 second
        // 2 = .5 seconds
        [SerializeField]
        private float _fadeSpeed;

        private string _sceneToLoad;

        // It is assumed that a new scene needs to be faded in to.
        private void Start()
        {
            FadeFromBlack();
        }

        public void ChangeScene(string scene)
        {
            _sceneToLoad = scene;
            FadeToBlack();
        }

        private void LoadScene()
        {
            SceneManager.LoadScene(_sceneToLoad);
        }

        private void FadeToBlack()
        {
            StartCoroutine(FadeToBlackRoutine());
        }

        private void FadeFromBlack()
        {
            StartCoroutine(FadeFromBlackRoutine());
        }

        private IEnumerator FadeToBlackRoutine()
        {
            Color objectColor = _fadeImage.color;
            float fadeAmount;

            _fadeImage.gameObject.SetActive(true);

            while (_fadeImage.color.a < 1)
            {
                fadeAmount = objectColor.a + (_fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);

                if (objectColor.a > 1)
                {
                    objectColor.a = 1;
                }
                _fadeImage.color = objectColor;
                yield return null;
            }
            LoadScene();
        }

        private IEnumerator FadeFromBlackRoutine()
        {
            Color objectColor = _fadeImage.color;
            float fadeAmount;

            while (_fadeImage.color.a > 0)
            {
                fadeAmount = objectColor.a - (_fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);

                if (objectColor.a < 0)
                {
                    objectColor.a = 0;
                }
                _fadeImage.color = objectColor;
                yield return null;
            }

            _fadeImage.gameObject.SetActive(false);
        }
    }
}