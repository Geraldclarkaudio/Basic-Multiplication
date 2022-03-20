﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using LoLSDK;
using TMPro;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class RightOrWrongDialog : MonoBehaviour
    {
        private Initializer init;
        public string[] lines;
        private int index;
        public TextMeshProUGUI textComponent;

        private float canProceed = -1;
        private float textRate = 3.5f;

        public GameObject mouseClickAnim;

        public GameObject dialogBox;

        public Scene scene;

        private void Start()
        {
            scene = SceneManager.GetActiveScene();
            init = GameObject.Find("App").GetComponent<Initializer>();
            StartDialogue();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                if(scene.name == "Planet1")
                {
                    if(index == 3)
                    {
                        mouseClickAnim.SetActive(false);

                        dialogBox.SetActive(false);
                    }
                }

                if(scene.name == "CargoShipScene")
                {
                    //dialogBox2
                    if (index == 1)//DIALOG SECTION CUSTOMIZATION
                    {

                        mouseClickAnim.SetActive(false);

                        dialogBox.SetActive(false);
                    }
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


