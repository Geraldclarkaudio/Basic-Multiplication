using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LoLSDK;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class QuestionDialog : MonoBehaviour
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
                i = 5;
                index = 5;
                //correctAnswer = false;
                textComponent.text = init.GetText(lines[index]);
                LOLSDK.Instance.SpeakText(lines[index]);
                canProceed = Time.time + textRate;
                
            }

            switch (i)
            {
                case 0:
                    scionIcon.SetActive(true);
                   
                    break;
                case 1:
                   
                    captainCarlaIcon.SetActive(true);
                    scionIcon.SetActive(false);
                    break;
                case 2:
                    
                    scionIcon.SetActive(true);
                    captainCarlaIcon.SetActive(false);
                    break;
                case 3:
                    captainCarlaIcon.SetActive(true);
                    scionIcon.SetActive(false);
                    break;
                case 4:
                    
                    captainCarlaIcon.SetActive(true);
                    
                    break;
                case 5:
                    captainCarlaIcon.SetActive(false);
                    scionIcon.SetActive(true);
                    
                    break;
                case 6:
                    captainCarlaIcon.SetActive(true);
                    scionIcon.SetActive(false);
                    break;
            }

         
            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                if (index == 4)
                {
                    index = 4;
                    QuestionPanel.SetActive(true);
                    DialogPanel.SetActive(false);
                    AudioManager.Instance.EndDialogSound();
                    index++;
                    i++; return;
                    
                }
              

                if(index == 6)
                {
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
