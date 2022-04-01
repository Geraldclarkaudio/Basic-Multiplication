using System.Collections;
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
        private GameObject scene2;

        // Start is called before the first frame update
        void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();

            textComponent.text = init.GetText(instructions);
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

        IEnumerator WaitToDeactive()
        {
            yield return new WaitForSeconds(2.0f);
            scene2.SetActive(true);
            question.SetActive(false);
            //Set the next cutscene active
            
        }
    }
}
