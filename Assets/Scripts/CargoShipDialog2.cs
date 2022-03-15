using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using LoLSDK;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class CargoShipDialog2 : MonoBehaviour
    {
        private Initializer init;
        public string[] lines;
        private int index;
        public TextMeshProUGUI textComponent;

        private float canProceed = -1;
        private float textRate = 0f;

        public GameObject mouseClickAnim;
        public GameObject dialogBox;
        public GameObject alien;

        public GameObject answerQuestionUI;

        private void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            StartDialogue();

        }

        private void Update()
        {


            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                //dialogBox2
                if (index == 1)//DIALOG SECTION CUSTOMIZATION
                {
                    //Show Answer Question UI

                    dialogBox.SetActive(false);
                    mouseClickAnim.SetActive(false);
                    alien.SetActive(false);

                    answerQuestionUI.SetActive(true);
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


