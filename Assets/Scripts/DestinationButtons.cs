using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.MultiplicationMastermind {
    public class DestinationButtons : MonoBehaviour
    {
        [SerializeField]
        private GameObject planet1Button;

        [SerializeField]
        private GameObject planet2Button;

        // Start is called before the first frame update
        void Start()
        {
            if (GameManager.Instance.cargoShipHelped == true)
            {
                planet1Button.SetActive(true);
                planet2Button.SetActive(true);
            }
        }
    }
}
