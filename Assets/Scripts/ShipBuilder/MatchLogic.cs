using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class MatchLogic : MonoBehaviour
    {
        static MatchLogic Instance;

        public int maxPoints = 3;
        public TextMeshProUGUI pointsText;
        public GameObject levelCompleted;
        private int points = 0;

        [SerializeField]
        private GameObject shipPart;

        [SerializeField]
        private GameObject CockpitQuestionsPanel;
        [SerializeField]
        private GameObject navButtons;

        [SerializeField]
        private GameObject transparentShipPart;
        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
        }

        void UpdatePointsText()
        {
            pointsText.text = points + "/" + maxPoints;
            if(points == maxPoints)
            {
                levelCompleted.SetActive(true);
                
                StartCoroutine(ShipPartEnable());

                //turn off this question panel
                CockpitQuestionsPanel.SetActive(false);
                GameManager.Instance.cockpitBuilt = true;
                //turn on the nav buttons
                navButtons.SetActive(true);

            }
        }

        public static void AddPoint()
        {
            AddPoints(1);
        }

        public static  void AddPoints(int points)
        {
            Instance.points += points;
            Instance.UpdatePointsText();
        }

        IEnumerator ShipPartEnable()
        {

            yield return new WaitForSeconds(1.0f);
            shipPart.SetActive(true);
            transparentShipPart.SetActive(false);
            levelCompleted.SetActive(false);
        }
    }
}
