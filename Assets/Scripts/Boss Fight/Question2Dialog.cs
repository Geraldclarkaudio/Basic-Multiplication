using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LoLSDK;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class Question2Dialog : MonoBehaviour
    {
        private Initializer init;


        public string[] lines;
        private int index;

        public TMP_Text textComponent;

        private float canProceed = -1;
        private float textRate = 3.5f; //forces text to wait 3.5 seconds

        public GameObject mouseClickAnim;
        public GameObject captainCarlaIcon;
        public GameObject scionIcon;

        public GameObject QuestionPanel;
        public GameObject DialogPanel;

        private int i;

        public bool correctAnswer = false;

        public GameObject asteroidStorm;

        // Start is called before the first frame update
        void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            StartDialogue();
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log("index is " + index);

            if (correctAnswer == true)
            {
                correctAnswer = false;
                index = 3;
                i = 3;
                textComponent.text = init.GetText(lines[index]);
                LOLSDK.Instance.SpeakText(lines[index]);
                canProceed = Time.time + textRate;
            }

            switch (i)
            {
                case 0:
                    scionIcon.SetActive(false);
                    captainCarlaIcon.SetActive(true);
                    break;
                case 1:
                    captainCarlaIcon.SetActive(true);

                    break;
                case 2:
                    captainCarlaIcon.SetActive(true);

                    break;
                case 3:
                    scionIcon.SetActive(true);
                    captainCarlaIcon.SetActive(false);
                    break;
                case 4:
                    scionIcon.SetActive(false);
                    captainCarlaIcon.SetActive(true);
                    break;
            }


            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            { 
                if(index == 2)
                {
                    index = 2;
                    DialogPanel.SetActive(false);
                    QuestionPanel.SetActive(true);
                    AudioManager.Instance.EndDialogSound();
                    index++;
                    i++;
                    return;
                }

                if (index == 4)
                {
                    
                    asteroidStorm.SetActive(true);
                    DialogPanel.SetActive(false);
                    AudioManager.Instance.EndDialogSound();
                    
                }

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
        }

        void StartDialogue()
        {
            index = 0;
            i = 0;
            textComponent.text = init.GetText(lines[index]);
            LOLSDK.Instance.SpeakText(lines[index]);
            canProceed = Time.time + textRate;
            AudioManager.Instance.DialogSound();

        }
        void NextLine()
        {
            if (index < lines.Length - 1)
            {
                index++;
                i++;
                textComponent.text = init.GetText(lines[index]);
                LOLSDK.Instance.SpeakText(lines[index]);
            }
        }
    }
}
