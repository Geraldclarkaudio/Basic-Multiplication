using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LoLSDK;
using UnityEngine.UI;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class ButtonTextDisplay : MonoBehaviour
    {
        private Initializer init;
        public TextMeshProUGUI cargoShipButton;
        public TextMeshProUGUI planet2Button;
        public TextMeshProUGUI planet3Button;

        // Start is called before the first frame update
        void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();

            cargoShipButton.text = init.GetText("planetSelectUIText1");
            planet2Button.text = init.GetText("planetSelectUIText2");
            planet3Button.text = init.GetText("planetSelectUIText3");
        }
    }
}
