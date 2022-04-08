using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LoLSDK;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class ScionSceneDialog : MonoBehaviour
    {
        private Initializer init;


        public string[] lines;
        private int index;

        public TextMeshProUGUI textComponent;

        private float canProceed = -1;
        private float textRate = 3.5f; //forces text to wait 3.5 seconds

        public GameObject mouseClickAnim;
        public GameObject captainCarlaIcon;
        public GameObject scionIcon;

        public GameObject dialogBox;
        public GameObject scene1;//Intro Scene

        // Start is called before the first frame update
        void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            StartDialogue();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0) && dialogBox.activeInHierarchy == false)
            {
                return;
            }

            if(index == 0) 
            {
                scionIcon.SetActive(true);
            }

            if(index == 1)
            {
                captainCarlaIcon.SetActive(true);
                scionIcon.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                if(index == 1)
                {
                    //index++;
                    dialogBox.SetActive(false);
                    scene1.SetActive(true);
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
                index++;
                textComponent.text = init.GetText(lines[index]);
                LOLSDK.Instance.SpeakText(lines[index]);
            }
        }
    }
}
