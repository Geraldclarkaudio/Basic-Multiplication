using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.MultiplicationMastermind {
    public class NewHBDialog : DialogClass
    {
        public GameObject dialogPanel;
        public GameObject avatar;
        public GameObject planetSelectionUI;
        public GameObject scionButton;

        private LanguageManager languageManager;

        public override void Start()
        {
            StartDialogue();
        }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                if (index == 2) // end of intro dialog
                {
                    // index = 2;
                    planetSelectionUI.SetActive(true);
                    dialogPanel.SetActive(false);
                    AudioManager.Instance.EndDialogSound();
                }

                if (index == 5) //enf of cargoship dialog
                {
                    // index = 5;
                    planetSelectionUI.SetActive(true);
                    dialogPanel.SetActive(false);
                    AudioManager.Instance.EndDialogSound();
                }

                if (index == 8) // end of post planet 1 dialog
                {
                    //index = 8;
                    planetSelectionUI.SetActive(true);
                    dialogPanel.SetActive(false);
                    AudioManager.Instance.EndDialogSound();
                }

                if (index == 9)
                {
                    // index = 9;
                    planetSelectionUI.SetActive(true);
                    scionButton.SetActive(true); // sets end game button to true. 
                    dialogPanel.SetActive(false);
                    AudioManager.Instance.EndDialogSound();

                }
            }
            base.Update();

        }

        public override void StartDialogue()
        {
            
            if (GameManager.Instance.cargoShipHelped == false) // beginning of game
            {
                index = 0;
            }

            if (GameManager.Instance.cargoShipHelped == true) // Cargo Ship Helped only. 
            {
                //display welcome back text
                index = 3;
            }
            if (GameManager.Instance.planet1Helped == true)
            {
                index = 6;
            }
            if (GameManager.Instance.planet2Helped == true)
            {
                index = 9;
            }
            index = 0;

            textComponent.text = languageManager.GetText(lines[index]);
            canProceed = Time.time + textRate;
            AudioManager.Instance.DialogSound();
        }
    }
}
