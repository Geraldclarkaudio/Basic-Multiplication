using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using LoLSDK;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class P1Intro : NotLOLDialogClass
    {
       
        public GameObject alien;
        public GameObject answerQuestionUI;
        public GameObject director;
        public GameObject cam2;
        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
               
                if (index == 5)
                {
                    nextCue.SetActive(false);
                    alien.SetActive(false);
                    director.SetActive(true);
                    AudioManager.Instance.EndDialogSound();
                    StartCoroutine(ShowAnswerUI());
                }
            }
            base.Update();
        }
        IEnumerator ShowAnswerUI()
        {
            yield return new WaitForSeconds(4.0f);
            answerQuestionUI.SetActive(true);
            dialogBox.SetActive(false);
        }
    }
}


