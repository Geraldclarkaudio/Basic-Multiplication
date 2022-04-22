using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleJSON;
using System.IO;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public abstract class NotLOLDialogClass : MonoBehaviour
    {
        private LanguageManager languageManager;

        [SerializeField]
        protected string[] lines;
        [SerializeField]
        protected int index;
        [SerializeField]
        protected int i;
        [SerializeField]
        protected TMP_Text textComponent;
        [SerializeField]
        protected GameObject nextCue;
        [SerializeField]
        protected float canProceed = -1;
        [SerializeField]
        protected float textRate = 3.5f; //forces text to wait 3.5 seconds
        [SerializeField]
        protected GameObject dialogBox;

        private void Awake()
        {
            languageManager = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();

        }

        public virtual void Start()
        {
            
                StartDialogue();
            
         
        }

        public virtual void Update()
        {
            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                if (textComponent.text == languageManager.GetText(lines[index]))
                {
                    NextLine();
                    canProceed = Time.time + textRate;
                }
                else
                {
                    textComponent.text = languageManager.GetText(lines[index]);
                }
            }
            if (Time.time >= canProceed)
            {
                nextCue.SetActive(true);
            }
            else if (Time.time < canProceed)
            {
                nextCue.SetActive(false);
            }
        }

        public virtual void StartDialogue()
        {
            index = 0;
            i = 0;
            textComponent.text = languageManager.GetText(lines[index]);
            canProceed = Time.time + textRate;
            AudioManager.Instance.DialogSound();
        }
        public virtual void NextLine()
        {
            if (index < lines.Length - 1)
            {
                index++;
                i++;
                textComponent.text = languageManager.GetText(lines[index]);
            }
        }
    }
}
