using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LoLSDK;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public abstract class DialogClass : MonoBehaviour
    {
        private Initializer init;
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

        public virtual void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            StartDialogue();
        }

        // Update is called once per frame
        public virtual void Update()
        {
            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
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
            textComponent.text = init.GetText(lines[index]);
            LOLSDK.Instance.SpeakText(lines[index]);
            canProceed = Time.time + textRate;
            AudioManager.Instance.DialogSound();
        }
        public virtual void NextLine()
        {
            if (index < lines.Length - 1)
            {
                index++;
                i++;
                textComponent.text = init.GetText(lines[index]);
                LOLSDK.Instance.SpeakText(lines[index]);
            }
        }
    }
}
