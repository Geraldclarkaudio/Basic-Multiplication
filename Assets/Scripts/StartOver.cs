using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.MultiplicationMastermind {
    public class StartOver : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameManager.Instance.cargoShipHelped = false;
            GameManager.Instance.planet1Helped = false;
            GameManager.Instance.planet2Helped = false;
        }
    }
}
