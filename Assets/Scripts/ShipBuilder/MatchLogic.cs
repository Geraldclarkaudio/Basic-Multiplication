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
        public TextMeshProUGUI cockpitPointsText;
        public TextMeshProUGUI bodyPointsText;
        public TextMeshProUGUI wingPointsText;
        public TextMeshProUGUI engineText;
        public GameObject levelCompleted;
        private int points = 0;

        [SerializeField]
        private GameObject shipPart1;
        [SerializeField]
        private GameObject shipPart2;
        [SerializeField]
        private GameObject shipPart3;
        [SerializeField]
        private GameObject shipPart4;



        [SerializeField]
        private GameObject navButtons;

        [SerializeField]
        private GameObject transparentShipPart1;
        [SerializeField]
        private GameObject transparentShipPart2;
        [SerializeField]
        private GameObject transparentShipPart3;
        [SerializeField]
        private GameObject transparentShipPart4;

        [SerializeField]
        private GameObject questionPanel1;
        [SerializeField]
        private GameObject questionPanel2;
        [SerializeField]
        private GameObject questionPanel3;
        [SerializeField]
        private GameObject questionPanel4;

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
        }

        void UpdatePointsText()
        {
            //COCKPIT::::::::::::::::::::::::::::::::
            if (questionPanel1.activeSelf == true)
            {
                
                cockpitPointsText.text = points + "/" + maxPoints;
                if (points == maxPoints)
                {
                    points = 0;
                    levelCompleted.SetActive(true);
                    GameManager.Instance.cockpitBuilt = true;
                    StartCoroutine(ShipPartEnable1());
                    //turn off this question panel
                   questionPanel1.SetActive(false);

                    //turn on the nav buttons
                    navButtons.SetActive(true);

                }
            }
            //BODY:::::::::::::::::::::::::::::
            if (questionPanel2.activeSelf == true)
            {   
                bodyPointsText.text = points + "/" + maxPoints;
                if (points == maxPoints)
                {
                    points = 0;
                    levelCompleted.SetActive(true);
                    GameManager.Instance.bodyBuilt = true;
                    StartCoroutine(ShipPartEnable2());
                    //turn off this question panel
                    questionPanel2.SetActive(false);

                    //turn on the nav buttons
                    navButtons.SetActive(true);

                }
            }
            //WINGS::::::::::::::::::::::::::::::::::::::::::::::
            if (questionPanel3.activeSelf == true)
            {
                wingPointsText.text = points + "/" + maxPoints;
                if (points == maxPoints)
                {
                    points = 0;
                    levelCompleted.SetActive(true);
                    GameManager.Instance.wingsBuilt = true;
                    StartCoroutine(ShipPartEnable3());
                    //turn off this question panel
                    questionPanel3.SetActive(false);

                    //turn on the nav buttons
                    navButtons.SetActive(true);

                }
            }
            //ENGINESSSS::::::::::::
            if (questionPanel4.activeSelf == true)
            {
                engineText.text = points + "/" + maxPoints;
                if (points == maxPoints)
                {
                    points = 0;
                    levelCompleted.SetActive(true);
                    GameManager.Instance.enginesBuilt = true;
                    StartCoroutine(ShipPartEnable4());
                    //turn off this question panel
                    questionPanel4.SetActive(false);

                    //turn on the nav buttons
                    navButtons.SetActive(true);

                }
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

        IEnumerator ShipPartEnable1()
        {

            yield return new WaitForSeconds(1.0f);
            shipPart1.SetActive(true);
            transparentShipPart1.SetActive(false);
            levelCompleted.SetActive(false);
        }
        IEnumerator ShipPartEnable2()
        {

            yield return new WaitForSeconds(1.0f);
            shipPart2.SetActive(true);
            transparentShipPart2.SetActive(false);
            levelCompleted.SetActive(false);
        }
        IEnumerator ShipPartEnable3()
        {

            yield return new WaitForSeconds(1.0f);
            shipPart3.SetActive(true);
            transparentShipPart3.SetActive(false);
            levelCompleted.SetActive(false);
        }
        IEnumerator ShipPartEnable4()
        {

            yield return new WaitForSeconds(1.0f);
            shipPart4.SetActive(true);
            transparentShipPart4.SetActive(false);
            levelCompleted.SetActive(false);
        }
    }
}
