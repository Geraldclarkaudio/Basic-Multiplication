using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class Selector : MonoBehaviour, IPointerClickHandler
    {
        private Image image;
        public bool selected = false;
        public GameObject answers;

        // Start is called before the first frame update
        void Start()
        {
            image = GetComponent<Image>();
            answers.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            image.color = Color.green;
            selected = true;
            Debug.Log("CLIKT");
            answers.SetActive(true);
        }
    }
}
