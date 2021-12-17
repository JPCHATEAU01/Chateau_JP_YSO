using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class SplashScreenManager : MonoBehaviour
    {
        private int wait_time = 4;
        private bool isLoaded = false;

        void Start()
        {
            StartCoroutine(Wait());
        }
        void Update()
        {
            if (isLoaded)
            {
                isLoaded = false;
                LaunchMenu();
            }
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(wait_time);
            isLoaded = true;
        }

        private void LaunchMenu()
        {
            GameManager.Instance().LaunchScene("MenuScene");
        }
    }
}