using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

namespace PaperKiteStudios.MultiplicationMastermind
{
    
    public class Completed : MonoBehaviour
    {
        public GameObject fadeout;
        public GameObject pleaseRatePanel;
        public void Comp()
        {
            AudioManager.Instance.ButtonClicked();
            fadeout.SetActive(true);
            pleaseRatePanel.SetActive(true);
            StartCoroutine(PleaseRate());
        }

        IEnumerator PleaseRate()
        {
            yield return new WaitForSeconds(10.0f);
            LOLSDK.Instance.CompleteGame();
        }
    }
}
