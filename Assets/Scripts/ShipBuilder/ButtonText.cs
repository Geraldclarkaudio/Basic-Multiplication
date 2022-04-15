using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class ButtonText : MonoBehaviour
    {
        //public TextMeshProUGUI[] texts;
        public TMP_Text[] texts;
        public string[] lines;
        private Initializer init;

        public int i;
      
        
        // Start is called before the first frame update
        void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();

            for (i = 0; i < lines.Length; i++)
            {
                texts[i].text = init.GetText(lines[i]);
            }
        }
    }
}
