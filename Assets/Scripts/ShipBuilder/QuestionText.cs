using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind {
    public class QuestionText : MonoBehaviour
    {
        public TMP_Text cockpitQuestionText;
        public TMP_Text bodyQuestionText;
        public TMP_Text wingsQuestionText;
        public TMP_Text engineQuestionText;

        public string cockpitText;
        public string bodyText;
        public string wingText;
        public string engineText;

        private Initializer init;

        // Start is called before the first frame update
        void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            
            cockpitQuestionText.text  = init.GetText(cockpitText);
            bodyQuestionText.text = init.GetText(bodyText);
            wingsQuestionText.text = init.GetText(wingText);
            engineQuestionText.text = init.GetText(engineText);
        }
    }
}
