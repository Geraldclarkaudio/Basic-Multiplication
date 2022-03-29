using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using LoLSDK;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class DialogShipBuilder : MonoBehaviour
    {
        private Initializer init;
        public string[] lines;
        private int index;
        public TextMeshProUGUI textComponent;

        private float canProceed = -1;
        private float textRate = 1f;

        public GameObject mouseClickAnim;
        public GameObject dialogCanvas;
        public GameObject alien;
        private CameraBlend cameraBlend;

        private void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            cameraBlend = GameObject.Find("CM StateDrivenCamera1").GetComponent<CameraBlend>();
            StartDialogue();

        }

        private void Update()
        {
            Debug.Log("Index: " + index);

            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                if(index == 2)
                {
                    //show the canvas and make the cameras work properly. 
                    cameraBlend.CockPit();
                    mouseClickAnim.SetActive(false);
                    alien.SetActive(false);
                    canProceed = Time.time + 500;
                    dialogCanvas.SetActive(false);
                }
                //if (index >= 4)//DIALOG SECTION CUSTOMIZATION
                //{
                //    //Show Answer Question UI
                //    mouseClickAnim.SetActive(false);
                //    alien.SetActive(false);
                //    canProceed = Time.time + 500;
                //    goToHangarButton.SetActive(true);
                //    dialogBox.SetActive(false);

                //}

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


