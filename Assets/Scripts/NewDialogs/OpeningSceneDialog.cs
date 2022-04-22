using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class OpeningSceneDialog : DialogClass
    {
        public GameObject homeBaseButton;
        public GameObject captainCarla;
        public GameObject scion;

        public GameObject introMusic;
        public GameObject scionMusic;

        private Animator introMusicAnim;
        private Animator scionMusicAnim;


        private Animator carlaAnim;

        public override void Start()
        {
            base.Start();
            introMusicAnim = GameObject.Find("IntroBGM").GetComponent<Animator>();
            scionMusicAnim = GameObject.Find("ScionBGM").GetComponent<Animator>();
        }

        public override void Update()
        {
            switch (i)
            {
                case 0:
                    captainCarla.SetActive(true);
                    introMusic.SetActive(true);
                    break;
                case 1:
                    captainCarla.SetActive(true);
                    break;
                case 2:
                    captainCarla.SetActive(true);
                    break;
                case 3:
                    captainCarla.SetActive(true);
                    break;
                case 4:
                    captainCarla.SetActive(true);
                    break;
                case 5:
                    captainCarla.SetActive(true);
                    break;
                case 6:
                    scion.SetActive(true);
                    captainCarla.SetActive(false);
                    introMusicAnim.SetTrigger("FadeOut");
                    scionMusicAnim.SetTrigger("FadeIn");
                    scionMusic.SetActive(true);
                    break;
                case 7:
                    scion.SetActive(true);
                    break;
                case 8:
                    captainCarla.SetActive(true);
                    captainCarla.transform.position = new Vector3(-655.37f, -550, -942);
                    carlaAnim = GameObject.Find("Captain Carla").GetComponent<Animator>();
                    carlaAnim.SetTrigger("LetsGo");
                    scion.SetActive(false);
                    // canProceed = Time.time + 1;
                    break;
            }
            if (Input.GetMouseButtonDown(0) && Time.time > canProceed)
            {
                if (index == 8)
                {
                    dialogBox.SetActive(false);
                    homeBaseButton.SetActive(true);
                    AudioManager.Instance.EndDialogSound();
                }
            }
            base.Update();
        }
    }
}
