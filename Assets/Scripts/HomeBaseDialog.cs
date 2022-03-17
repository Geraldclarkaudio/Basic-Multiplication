﻿using System.Collections;
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
        public GameObject welcomeBackBox;

        public GameObject planetSelectionUI; 

        private void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            StartDialogue();     
            
            if(GameManager.Instance.cargoShipHelped == true)
            {
                welcomeBackBox.SetActive(true);
            }
            else if(GameManager.Instance.cargoShipHelped == false)
            {
                dialogBox.SetActive(true);
            }

        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                if(index == 2)
                {
                    planetSelectionUI.SetActive(true);
                    dialogPanel.SetActive(false);
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

       
