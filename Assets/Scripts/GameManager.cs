using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.MultiplicationMastermind
{
    
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    Debug.LogError("GameManager is null");
                }
                return _instance;
            }
        }

        public bool cargoShipHelped { get; set; }
        public bool planet1Helped { get; set; }
        public bool planet2Helped { get; set; }

        public bool cockpitBuilt { get; set; }
        public bool bodyBuilt { get; set; }
        public bool enginesBuilt { get; set; }
        public bool wingsBuilt { get; set; }






        private void Awake()
        {
            if(_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}
