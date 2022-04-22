using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class HBButtonText : MonoBehaviour
    {
        private LanguageManager languageManager;

        public TMP_Text cargoShipButton;
        public TMP_Text planet2Button;
        public TMP_Text planet3Button;
        public TMP_Text teachScionButton;

        private void Awake()
        {
            languageManager = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
        }
        // Start is called before the first frame update
        public void Start()
        {  
            cargoShipButton.text = languageManager.GetText("planetSelectUIText1");
            planet2Button.text = languageManager.GetText("planetSelectUIText2");
            planet3Button.text = languageManager.GetText("planetSelectUIText3");
            teachScionButton.text = languageManager.GetText("teachScionText");
        }
    }
}
