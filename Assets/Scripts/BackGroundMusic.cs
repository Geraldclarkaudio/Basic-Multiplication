using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class BackGroundMusic : MonoBehaviour
    {
        private static BackGroundMusic _instance;
        public static BackGroundMusic Instnce
        {
            get
            {
                if(_instance == null)
                {
                    Debug.LogError("BGM is Null");
                }

                return _instance;
            }
        }

        public AudioClip introClip;
        public AudioClip scionClip;

        private void Awake()
        {
            if(_instance!= null && _instance != this)
            {
                Destroy(this.gameObject);
            }

            else
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }

    }
}