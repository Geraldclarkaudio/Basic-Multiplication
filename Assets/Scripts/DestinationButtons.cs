using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PaperKiteStudios.MultiplicationMastermind {
    public class DestinationButtons : MonoBehaviour
    {
        [SerializeField]
        private Button cargoShipButton;
        [SerializeField]
        private Button planet1ButtonInteract;
        [SerializeField]
        private Button planet2ButtonInteract;

        [SerializeField]
        private GameObject planet1Button;

        [SerializeField]
        private GameObject planet2Button;

        public GameObject cargoCheckMarkBox;
        public GameObject planet1CheckMarkBox;
        public GameObject planet2CheckMarkBox;
        public Sprite checkMarkOff;
        public Sprite checkMarkOn;


        // Start is called before the first frame update
        void Start()
        {
            
            if (GameManager.Instance.cargoShipHelped == true)
            {
                //Cant go back to the same scene. 
                cargoShipButton.interactable = false;
                //put check mark in the box. 
                cargoCheckMarkBox.GetComponent<Image>().sprite = checkMarkOn;
                //set these buttons true now. Happens once Cargo ship is helped. Stay active throughout the game. 
                planet1Button.SetActive(true);
                //planet2Button.SetActive(true);
            }

            if(GameManager.Instance.planet1Helped == true)
            {
                //Cant go back to Scene again
                planet1ButtonInteract.interactable = false;
                //put check mark 
                planet1CheckMarkBox.GetComponent<Image>().sprite = checkMarkOn;
                planet2Button.SetActive(true);
            }

            if(GameManager.Instance.planet2Helped == true)
            {
                planet2ButtonInteract.interactable = false;
                planet2CheckMarkBox.GetComponent<Image>().sprite = checkMarkOn;
            }
        }
    }
}
