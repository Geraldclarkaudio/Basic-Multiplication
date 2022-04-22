using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using LoLSDK;
using TMPro;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class CargoRightWrong : NotLOLDialogClass
    { 
        public Scene scene;

        public override void Start()
        {
            scene = SceneManager.GetActiveScene();
            base.Start();
        }

        public override void Update()
        {
            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                if (scene.name == "Planet1")
                {
                    if (index == 3)
                    {
                        nextCue.SetActive(false);
                        dialogBox.SetActive(false);
                    }
                }

                if (scene.name == "CargoShipScene")
                {  
                    if (index == 1)
                    {
                        nextCue.SetActive(false);
                        dialogBox.SetActive(false);
                    }
                }
            }
            base.Update();
        }
    }
}


