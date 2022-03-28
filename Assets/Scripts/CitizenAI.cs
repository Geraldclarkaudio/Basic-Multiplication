using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace PaperKiteStudios.MultiplicationMastermind
{

    public class CitizenAI : MonoBehaviour
    {
        private NavMeshAgent _agent;
        [SerializeField]
        private List<Transform> waypoints;
        public bool reverse = false;
        public int currentTarget;

        private Animator _anim;

        // Start is called before the first frame update
        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            currentTarget = 1;
            _anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if(GameManager.Instance. planet1Helped == false)
            {
                Movement();
            }

            else if(GameManager.Instance.planet1Helped == true)
            {
                //set animation to be celebratory
                _anim.SetBool("Helped", true);
            }
        }

        private void Movement()
        {
            if (waypoints.Count > 0 && waypoints[currentTarget] != null)
            {
                _agent.SetDestination(waypoints[currentTarget].position);
            }

            float distance = Vector3.Distance(transform.position, waypoints[currentTarget].position);

            if (distance < 1.0f)
            {
                if (reverse == true)
                {
                    currentTarget--;

                    if (currentTarget == 0)
                    {
                        reverse = false;
                        currentTarget = 0;
                    }
                }
                else
                {
                    currentTarget++;

                    if (currentTarget == waypoints.Count) //at the end
                    {
                        reverse = true;
                        currentTarget--;
                    }
                }

            }

        }

    }
}
