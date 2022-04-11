using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using LoLSDK;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class HomeBaseDialog : MonoBehaviour
    {
        private Initializer init;
        public string[] lines;
        private int index;
        private int i;
        public TextMeshProUGUI textComponent;

        private float canProceed = -1;
        private float textRate = 3.5f;

        public GameObject mouseClickAnim;
        public GameObject dialogPanel;
        public GameObject avatar;
        public GameObject dialogBox;

        public GameObject planetSelectionUI;

        public GameObject scionButton;

        private void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            StartDialogue();

            if (GameManager.Instance.cargoShipHelped == false) // beginning of game
            {
                index = 0;
            }

            if (GameManager.Instance.cargoShipHelped == true) // Cargo Ship Helped only. 
            {
                //display welcome back text
                index = 3;
            }
            if(GameManager.Instance.planet1Helped == true)
            {
                index = 6;
            }
            if (GameManager.Instance.planet2Helped == true)
            {
                index = 9;
            }

        }

            private void Update()
        {
            Debug.Log("index = " + index);

            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                if(index == 2) // end of intro dialog
                {
                    index = 2;
                    planetSelectionUI.SetActive(true);
                    dialogPanel.SetActive(false);
                    AudioManager.Instance.EndDialogSound();
                    mouseClickAnim.SetActive(false);
                }

                if(index == 5) //enf of cargoship dialog
                {
                    index = 5;
                    planetSelectionUI.SetActive(true);
                    dialogPanel.SetActive(false);
                    AudioManager.Instance.EndDialogSound();
                    mouseClickAnim.SetActive(false);

                }

                if (index == 8) // end of post planet 1 dialog
                {
                    index = 8;
                    planetSelectionUI.SetActive(true);
                    dialogPanel.SetActive(false);
                    AudioManager.Instance.EndDialogSound();
                    mouseClickAnim.SetActive(false);

                }

                if (index == 9)
                {
                    index = 9;
                    planetSelectionUI.SetActive(true);
                    scionButton.SetActive(true); // sets end game button to true. 
                    mouseClickAnim.SetActive(false);
                    dialogPanel.SetActive(false);
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
            textComponent.text = init.GetText(lines[index]);
            LOLSDK.Instance.SpeakText(lines[index]);
            canProceed = Time.time + textRate;
            AudioManager.Instance.DialogSound();
        }
        void NextLine()
        {
            if (index < lines.Length - 1)
            {
                if(index == 2 || index == 5 || index == 8 || index == 9)
                {
                    return;
                }

                else
                {
                    index++;
                    textComponent.text = init.GetText(lines[index]);
                    LOLSDK.Instance.SpeakText(lines[index]);
                }
                
            }
        }
    }
}

       
