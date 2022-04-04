using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.MultiplicationMastermind
{
    public class Spaceship : MonoBehaviour
    {
        public float _speed = 15f;
        private float canFire = -1;
        private float fireRate = 0.20f;

        [SerializeField]
        private GameObject laserPrefab;
        [SerializeField]
        private GameObject doubleLaser;

        public bool hasDoubleLaser = false;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
            Fire();
        }

        public void Movement()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

            transform.Translate(direction * _speed * Time.deltaTime);

            //WRAPPING
            if (transform.position.y > 48f)
            {
                transform.position = new Vector3(transform.position.x, -15f, 0);
            }
            if (transform.position.y < -15f)
            {
                transform.position = new Vector3(transform.position.x, 48f, 0);
            }

            //Boundary on vertical inputs
            if (transform.position.x >= 11.5f)
            {
                transform.position = new Vector3(11.5f, transform.position.y, 0);
            }
            if (transform.position.x <= 3.0f)
            {
                transform.position = new Vector3(3.0f, transform.position.y, 0);
            }

            //Boost
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _speed = _speed + 20f;
                //Make boosters bigger

            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _speed = _speed - 20f;
            }
        }

        public void Fire()
        {
            if(hasDoubleLaser == false)
            {
                if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
                {
                    canFire = Time.time + fireRate;
                    Instantiate(laserPrefab, transform.position, Quaternion.identity);
                }
            }

           else if(hasDoubleLaser == true)
            {
                if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
                {
                    canFire = Time.time + fireRate;
                    Instantiate(doubleLaser, transform.position, Quaternion.identity);
                }
            }
          
        }
    }
}
