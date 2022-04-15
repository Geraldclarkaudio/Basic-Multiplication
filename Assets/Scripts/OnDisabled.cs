using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class OnDisabled : MonoBehaviour
    {
        public GameObject backToHomeBaseButton;

        private void OnDisable()
        {
            backToHomeBaseButton.SetActive(true);
        }
    }
}
