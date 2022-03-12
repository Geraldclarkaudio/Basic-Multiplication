using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class RotateSky : MonoBehaviour
    {
        private float rotateSpeed = 0.5f;

        // Update is called once per frame
        void Update()
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * -rotateSpeed);
        }
    }
}
