using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using LoLSDK;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class P1Correct : NotLOLDialogClass
    {
        public GameObject alien;
        public GameObject director;
        public override void Start()
        {
            base.Start();
            director.SetActive(true);
            alien.SetActive(true);
        }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                //dialogBox2
                if (index == 4)//DIALOG SECTION CUSTOMIZATION
                {
                    nextCue.SetActive(false);
                    alien.SetActive(false);
                    dialogBox.SetActive(false);
                    AudioManager.Instance.EndDialogSound();
                }
            }
            base.Update();
        }
    }
}


