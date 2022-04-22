using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class Instructions : MonoBehaviour
    {
        [SerializeField]
        private string instructions;
        [SerializeField]
        private TMP_Text textComponent;

        private LanguageManager languageManager;
        // Start is called before the first frame update
        void Start()
        {
            languageManager = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
            textComponent.text = languageManager.GetText(instructions);
        }
    }
}
