using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Resources.Scripts
{
    public class SplashScreenManager : MonoBehaviour
    {
        private int wait_time = 4;
        private bool isLoaded = false;
        private SaveLoadDataIntoJson<Volume> volumeData;
        private Volume volume;

        void Awake()
        {

            volumeData = new SaveLoadDataIntoJson<Volume>("/Volume.json");
            try
            {
                volume = volumeData.LoadObject();
            }
            catch (Exception e)
            {
                Debug.Log(e);
                volume = new Volume(0.5f);
                volumeData.SaveIntoJson(volume);
            }
            Debug.Log(volume.ToString());
        }

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