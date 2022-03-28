﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.MultiplicationMastermind {
    public class CameraBlend : MonoBehaviour
    {
        private Animator _anim;

        // Start is called before the first frame update
        void Start()
        {
            _anim = GetComponent<Animator>();
        }

        public void CockPit()
        {
            _anim.SetFloat("Switch", 1f);
        }
        public void Body()
        {
            _anim.SetFloat("Switch", 2);
        }
        public void Wings()
        {
            _anim.SetFloat("Switch", 3);
        }
        public void Engine()
        {
            _anim.SetFloat("Switch", 4);
        }
    }
}