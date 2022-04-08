using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using LoLSDK;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class Planet2IntroDialog : MonoBehaviour
    {
        private Initializer init;
        public string[] lines;
        private int index;
        public TextMeshProUGUI textComponent;

        private float canProceed = -1;
        private float textRate = 1f;

        public GameObject mouseClickAnim;
        public GameObject dialogBox;
        public GameObject alien;
        public GameObject goToHangarButton;

        private void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            StartDialogue();

        }

        private void Update()
        {
            Debug.Log("Index: " + index);
            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                //dialogBox2
                if (index >= 4)//DIALOG SECTION CUSTOMIZATION
                {
                    //Show Answer Question UI
                    mouseClickAnim.SetActive(false);
                    alien.SetActive(false);
                    canProceed = Time.time + 500;
                    goToHangarButton.SetActive(true);
                    AudioManager.Instance.EndDialogSound();
                    dialogBox.SetActive(false);     
                    
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
                index++;
                textComponent.text = init.GetText(lines[index]);
                LOLSDK.Instance.SpeakText(lines[index]);
            }
        }

    }
}


