using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class CargoShip2 : NotLOLDialogClass
    {
        public GameObject alien;
        public GameObject answerQuestionUI;

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                //dialogBox2
                if (index == 1)//DIALOG SECTION CUSTOMIZATION
                {
                    //Show Answer Question UI

                    dialogBox.SetActive(false);
                    nextCue.SetActive(false);
                    alien.SetActive(false);
                    AudioManager.Instance.EndDialogSound();

                    answerQuestionUI.SetActive(true);
                }
            }
            base.Update();

        }
    }
}


