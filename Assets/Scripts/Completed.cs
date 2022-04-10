using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

namespace PaperKiteStudios.MultiplicationMastermind
{

    public class Completed : MonoBehaviour
    {
        public void Comp()
        {
            LOLSDK.Instance.CompleteGame();
        }
    }
}
