﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{

    public class RightWrong : MonoBehaviour
    {
        private Initializer init;
        [SerializeField]
        private string instructions;
        [SerializeField]
        private string wrongAnswer;
        [SerializeField]
        private string rightAnswer;
        [SerializeField]
        private TMP_Text textComponent;

        [SerializeField]
        private GameObject question;

        [SerializeField]
        private GameObject dialogBox;

        //private QuestionDialog questionDialog;
        public QuestionDialog questionDialog;
        public Question2Dialog question2Dialog;


        // Start is called before the first frame update
        void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            textComponent.text = init.GetText(instructions);
          //  questionDialog = GameObject.Find("Question1DialogPanel").GetComponent<QuestionDialog>();
        }

        public void WrongAnswer()
        {
            textComponent.text = init.GetText(wrongAnswer);
        }

        public void RightAnswer()
        {
            textComponent.text = init.GetText(rightAnswer);
            

            StartCoroutine(WaitToDeactive());
        }

        public void RightAnswer2()
        {
            textComponent.text = init.GetText(rightAnswer);


            StartCoroutine(WaitToDeactive2());
        }

        IEnumerator WaitToDeactive()
        {
            yield return new WaitForSeconds(2.0f);
         
            question.SetActive(false);
            //Set the next cutscene active
            dialogBox.SetActive(true);
            questionDialog.correctAnswer = true;

        }
        IEnumerator WaitToDeactive2()
        {
            yield return new WaitForSeconds(2.0f);

            question.SetActive(false);
            //Set the next cutscene active
            dialogBox.SetActive(true);
            question2Dialog.correctAnswer = true;

        }
    }
}