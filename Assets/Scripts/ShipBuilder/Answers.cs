using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class Answers : MonoBehaviour
    {
        private Selector selector;
        private Image selectorImage;

        public bool clickedWrong1 = false;
        public bool clikcedWrong2 = false;

        public Button correctAnswer;
        public Button otherAnswer1;
        public Button otherAnswer2;

        public Sprite redSprite;
        public Sprite regularSprite;

        [SerializeField]
        private GameObject line;
        // Start is called before the first frame update
        void Start()
        {
            selector = GameObject.Find("2+2+2").GetComponent<Selector>();
           
            selectorImage = GameObject.Find("2+2+2").GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
       
        }

        public void CorrectAnswer()
        {
          
            Debug.Log("Correct!");
            selector.selected = false;
            line.SetActive(true);
            correctAnswer.interactable = false;
            selectorImage.color = new Color(selectorImage.color.r, selectorImage.color.g, selectorImage.color.b, 0.60f);
            
            Destroy(selector);            
        }

        public void WrongAnswer()
        {
            if(clickedWrong1 == true)
            {
                Debug.Log("TryAgain!");
                StartCoroutine(Wrong1Flash());
            }
            if(clikcedWrong2 == true)
            {
                Debug.Log("TryAgain!");
                StartCoroutine(Wrong2Flash());
            }

        }

        IEnumerator Wrong1Flash()//oother answer is wrong.. need to say IF specific nswer then bleh. 
        { 
            yield return new WaitForSeconds(0.25f);
            otherAnswer1.GetComponent<Image>().sprite = redSprite;
            yield return new WaitForSeconds(0.25f);
            otherAnswer1.GetComponent<Image>().sprite = regularSprite;
            yield return new WaitForSeconds(0.25f);
            otherAnswer1.GetComponent<Image>().sprite = redSprite;
            yield return new WaitForSeconds(0.25f);
            otherAnswer1.GetComponent<Image>().sprite = regularSprite;
            clickedWrong1 = false;
        }
        IEnumerator Wrong2Flash()//oother answer is wrong.. need to say IF specific nswer then bleh. 
        {
            yield return new WaitForSeconds(0.25f);
            otherAnswer2.GetComponent<Image>().sprite = redSprite;
            yield return new WaitForSeconds(0.25f);
            otherAnswer2.GetComponent<Image>().sprite = regularSprite;
            yield return new WaitForSeconds(0.25f);
            otherAnswer2.GetComponent<Image>().sprite = redSprite;
            yield return new WaitForSeconds(0.25f);
            otherAnswer2.GetComponent<Image>().sprite = regularSprite;
            clikcedWrong2 = false;
        }

        public void ClickedWrong1()
        {
            clickedWrong1 = true;
        }
        public void ClickedWrong2()
        {
            clikcedWrong2 = true;
        }
    }
}