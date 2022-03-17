using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class DropSlot : MonoBehaviour, IDropHandler
    {
        [SerializeField]
        private TextMeshProUGUI text;

        //private ReactantAdd reactantAdd;
        public bool canDrop;

        private DragDrop ogPos;

        [SerializeField]
        private GameObject wrongAnswerPanel;

        [SerializeField]
        private GameObject answerQuestionUI;

        [SerializeField]
        private GameObject corectAnswerDialogBox; 

        private void Start()
        {
            //reactantAdd = GameObject.Find("Reactant_Zone").GetComponent<ReactantAdd>();
            canDrop = true;
            
        }
        public void OnDrop(PointerEventData eventData)
        {
            if (canDrop == true)
            {
                text.text = "";
                canDrop = false;
                Cursor.lockState = CursorLockMode.None;

                if (eventData.pointerDrag != null)
                {
                    if(eventData.pointerDrag.tag == "WrongAnswer")
                    {
                        ogPos = eventData.pointerDrag.GetComponent<DragDrop>();
                        Debug.Log("WRONG");
                        canDrop = true;

                        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = ogPos.originalPosition;

                        //Make Alien Dialog Box Pop up and reiterate the point. 
                        wrongAnswerPanel.SetActive(true);

                        return;
                    }
                    else
                    {
                        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
                        Debug.Log("Dropped" + eventData.pointerDrag.name);
                        eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;

                    }

                }
            }

        }

        private void Update()
        {
            if(canDrop == false)
            {
                StartCoroutine(WaitToMoveOn());
            }
        }

        IEnumerator WaitToMoveOn()
        {
            yield return new WaitForSeconds(2.0f);
            //next dialog == got it right!
            corectAnswerDialogBox.SetActive(true);
            answerQuestionUI.SetActive(false);

        }
    }
}
