using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using LoLSDK;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class CargoShip1 : DialogClass
    {
        
        public GameObject alien;

        public GameObject multiplicativeSentence;

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
                }
                //dialogBox1
                if (index == 6)//DIALOG SECTION CUSTOMIZATION
                {
                    //Show Multiplicative Sentence
                    //mouseClickAnim.SetActive(false);
                    dialogBox.SetActive(false);
                    AudioManager.Instance.EndDialogSound();
                    multiplicativeSentence.SetActive(true);
                }
            }

            base.Update();
        }
    }
}


