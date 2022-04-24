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
    public class FinalDia : MonoBehaviour
    {
        private Initializer init;
        public string[] lines;
        public int index;
        public TextMeshProUGUI textComponent;

        private float canProceed = -1;
        private float textRate = 3.5f;

        public GameObject mouseClickAnim;
        public GameObject dialogCanvas;
        public GameObject alien;

        public string sceneToLoad;
        public GameObject fadeout;

        private void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            StartDialogue();

        }

        private void Update()
        {
            Debug.Log("Index: " + index);

            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                if (index == 1)
                { 
                    StartCoroutine(LoadNextScene());
                    fadeout.SetActive(true);
                    GameManager.Instance.planet2Helped = true;
                    AudioManager.Instance.EndDialogSound();
                }

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
                mouseClickAnim.SetActive(true);
            }
            else if (Time.time < canProceed)
            {
                mouseClickAnim.SetActive(false);
            }
        }

        void StartDialogue()
        {
            index = 0;
            textComponent.text = init.GetText(lines[index]);
            LOLSDK.Instance.SpeakText(lines[index]);
            canProceed = Time.time + textRate;
            AudioManager.Instance.DialogSound();
        }
        void NextLine()
        {
            if (index < lines.Length - 1)
            {
                index++;
                textComponent.text = init.GetText(lines[index]);
                LOLSDK.Instance.SpeakText(lines[index]);
            }
        }

        IEnumerator LoadNextScene()
        {
            yield return new WaitForSeconds(2.5f);
            SceneManager.LoadScene(sceneToLoad);

        }

    }
}


