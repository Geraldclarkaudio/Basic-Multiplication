using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class Laser : MonoBehaviour
    {
        public float _speed = 25f;
     // Update is called once per frame
        void Update()
        {
            Movement();
        }

        void Movement()
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
            Destroy(this.gameObject, 2f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Scion"))
            {
                Destroy(this.gameObject);
            }

            if(other.CompareTag("Asteroid"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}