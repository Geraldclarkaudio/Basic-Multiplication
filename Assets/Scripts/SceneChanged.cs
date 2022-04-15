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
        private Fallback fallback;


        private void Start()
        {
            if(init != null)
            {
                Scene scene = SceneManager.GetActiveScene();
                Debug.Log("Active Scene is " + scene.name);

                init = GameObject.Find("App").GetComponent<Initializer>();

                init.SceneChanged();
            }
            else
            {
                Scene scene = SceneManager.GetActiveScene();

                fallback = GameObject.Find("Fallback").GetComponent<Fallback>();
                fallback.SceneChanged();
            }
            

        }

    }
}
