using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{

    public class InstructionalText : MonoBehaviour
    {
        private Initializer init;
        [SerializeField]
        private string instructions;
        [SerializeField]
        private TextMeshProUGUI textComponent;
        
        // Start is called before the first frame update
        void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();

            textComponent.text = init.GetText(instructions);
        }
    }
}
