using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LoLSDK;

namespace PaperKiteStudios.MultiplicationMastermind {
    public class Dialog : MonoBehaviour
    {
        private Initializer init;

    
        public string[] lines;
        private int index;

        private int i;

        public TextMeshProUGUI textComponent;

        private float canProceed = -1;
        private float textRate = 0f; //forces text to wait 4 seconds

        public GameObject mouseClickAnim;
        public GameObject captainCarla;
        public GameObject scion;

        // Start is called before the first frame update
        void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            i = lines[index].IndexOf(lines[index]);

            StartDialogue();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {

                if (textComponent.text == init.GetText(lines[index]))
                {
                    NextLine();
                    canProceed = Time.time + textRate;
                }
                else
                {
                    textComponent.text = init.GetText(lines[index]);
                }
            }

            if (Time.time >= canProceed)
            {
                mouseClickAnim.SetActive(true);
            }
            else if (Time.time < canProceed)
            {
                mouseClickAnim.SetActive(false);
            }
            
            if (i >= 0 && i <= 5)
            {
                captainCarla.SetActive(true);
                scion.SetActive(false);
            }
            
            else if(i == 6 || i == 7)
            {
                captainCarla.SetActive(false);
                scion.SetActive(true);
            }
        }

        void StartDialogue()
        {
            index = 0;
            textComponent.text = init.GetText(lines[index]);
            LOLSDK.Instance.SpeakText(lines[index]);
            canProceed = Time.time + textRate;
        }
        void NextLine()
        {
            if (index < lines.Length - 1)
            {
                index++;
                textComponent.text = init.GetText(lines[index]);
                LOLSDK.Instance.SpeakText(lines[index]);
            }
        }
    }
}
