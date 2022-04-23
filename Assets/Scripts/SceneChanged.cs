using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class SceneChanged : MonoBehaviour
    {


        private Initializer init;
   

        private void Start()
        {
                Scene scene = SceneManager.GetActiveScene();
                Debug.Log("Active Scene is " + scene.name);
                init = GameObject.Find("App").GetComponent<Initializer>();
                init.SceneChanged();
        }

    }
}
