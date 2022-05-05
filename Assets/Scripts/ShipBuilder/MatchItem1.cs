using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class MatchItem1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Canvas canvas;

        public bool wasClicked = false;
        public bool MATCH = false;
        public bool clickable = true;
        public bool clickedWrong = false;
        private Image image;

        private MatchItem1 partner;
        private MatchItem1 twomatch;

        private MatchItem1 threepartner;
        private MatchItem1 threematch;

        private MatchItem1 fivePartner;
        private MatchItem1 fiveMatch;


        public Sprite hoverImage;
        public Sprite originalImage;
        public Sprite clickedImage;

        [SerializeField]
        private GameObject match1;
        [SerializeField]
        private GameObject match2;
        [SerializeField]
        private GameObject match3;

        private void Start()
        {
            image = GetComponent<Image>();

            twomatch = GameObject.Find("2+2+2 Match").GetComponent<MatchItem1>();
            partner = GameObject.Find("2+2+2").GetComponent<MatchItem1>();

            threematch = GameObject.Find("3+3+3 Match").GetComponent<MatchItem1>();
            threepartner = GameObject.Find("3+3+3").GetComponent<MatchItem1>();

            fiveMatch = GameObject.Find("5 Match").GetComponent<MatchItem1>();
            fivePartner = GameObject.Find("5+5+5+5").GetComponent<MatchItem1>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            image.sprite = hoverImage;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(clickedWrong == true)
            {
                image.sprite = hoverImage;
            }
            else
            {
                image.sprite = originalImage;
            }
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            //CLICK FIRST OPTION AREA::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            if(clickable == true)
            {
                if (this.name == "2+2+2")
                {
                    wasClicked = true;

                    //if 3+3+3 or 5+5+5 was clicked, set was clicked to false for them.
                    threepartner.wasClicked = false;
                    threepartner.image.sprite = originalImage;
                    fivePartner.wasClicked = false;
                    fivePartner.image.sprite = originalImage;
                }
                if (this.name == "3+3+3")
                {
                    wasClicked = true;
                   
                    partner.wasClicked = false;
                    partner.image.sprite = originalImage;
                    fivePartner.wasClicked = false;
                    fivePartner.image.sprite = originalImage;
                }
                if (this.name == "5+5+5+5")
                {
                    wasClicked = true;

                    partner.wasClicked = false;
                    partner.image.sprite = originalImage;
                    threepartner.wasClicked = false;
                    threepartner.image.sprite = originalImage;
                }

                //MATCH LOGIC::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                //INCORRECT
                if (this.Equals(threematch) && partner.wasClicked == true || this.Equals(fiveMatch) && partner.wasClicked == true)
                {
                    
                    StartCoroutine(WrongFlash());
                }
                if (this.Equals(twomatch) && threepartner.wasClicked == true || this.Equals(fiveMatch) && threepartner.wasClicked == true)
                {
                    
                    StartCoroutine(WrongFlash());
                }
                if (this.Equals(twomatch) && fivePartner.wasClicked == true || this.Equals(threematch) && fivePartner.wasClicked == true)
                {
                    
                    StartCoroutine(WrongFlash());
                }

                //CORRECT
                if (this.Equals(twomatch))
                {
                    if (partner.wasClicked == true)
                    {
                        twomatch.wasClicked = true;//keeps the sprite green
                        partner.clickable = false;//unable to reselect partner
                        partner.wasClicked = false;
                        twomatch.clickable = false;//unable to continuously get points
                        MatchLogic.AddPoint(); // adds a point
                        MATCH = true; // keeps sprite green and doesnt allow more clicks 
                        partner.MATCH = true; //keeps sprite green and doesnt allow more clicks
                        match1.SetActive(true); //set line true
                    }
                }


                if (this.Equals(threematch))
                {
                    if (threepartner.wasClicked == true)
                    {
                        threematch.wasClicked = true;
                        threepartner.clickable = false;
                        threepartner.wasClicked = false;
                        threematch.clickable = false;
                        MatchLogic.AddPoint();
                        MATCH = true;
                        threepartner.MATCH = true;
                        match2.SetActive(true); //set line true
                    }
                }
                if (this.Equals(fiveMatch))
                {
                    if (fivePartner.wasClicked == true)
                    {
                        fiveMatch.wasClicked = true;
                        fivePartner.clickable = false;
                        fivePartner.wasClicked = false;
                        fiveMatch.clickable = false;
                        MatchLogic.AddPoint();
                        MATCH = true;
                        fivePartner.MATCH = true;
                        match3.SetActive(true); //set line true
                    }
                }
            }
           
        }

        private void Update()
        {
           if(wasClicked == true)
            {
                image.sprite = clickedImage;
            }

           if(MATCH == true)
            {
                clickable = false;
                image.sprite = clickedImage;
            }
        }

        IEnumerator WrongFlash()
        {
            AudioManager.Instance.WrongAnswer();
            clickedWrong = true;
            image.color = Color.red;
            yield return new WaitForSeconds(0.35f);
            image.color = Color.white;
            yield return new WaitForSeconds(0.35f);
            image.color = Color.red;
            yield return new WaitForSeconds(0.35f);
            image.color = Color.white;
            yield return new WaitForSeconds(0.35f);
            clickedWrong = false;
            image.sprite = originalImage;
        }
    }
}
