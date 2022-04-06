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

        public GameObject panel1;
        public GameObject panel2;
        public GameObject panel3;
        public GameObject panel4;
        public GameObject panel5;
        public GameObject panel6;
        public GameObject panel7;
        public GameObject panel8;
        public GameObject panel9;
       

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            Movement();

            if(panel1.activeSelf == true || panel2.activeSelf == true || panel3.activeSelf == true || panel4.activeSelf == true || panel5.activeSelf == true || panel6.activeSelf == true || panel7.activeSelf == true || panel8.activeSelf == true || panel9.activeSelf == true)
            {
                return;
            }
            else
            {
                Fire();
            }
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
