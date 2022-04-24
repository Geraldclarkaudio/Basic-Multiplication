using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class IndexIncrement : MonoBehaviour
    {
        private DialogShipBuilder dialog;

        // Start is called before the first frame update
        void Start()
        {
            dialog = GameObject.Find("DIALOGS").GetComponent<DialogShipBuilder>();
        }

        public void Increment()
        {
            dialog.index = 3;
        }
    }
}
