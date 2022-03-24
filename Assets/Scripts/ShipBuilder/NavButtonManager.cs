using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class NavButtonManager : MonoBehaviour
    {
        public Button cockpitButton;
        public Button wingsButton;
        public Button bodyButton;
        public Button enginesButton;



        // Update is called once per frame
        void Update()
        {
           if(GameManager.Instance.cockpitBuilt == true)
            {
                cockpitButton.enabled = false;
            }
        }
    }
}
