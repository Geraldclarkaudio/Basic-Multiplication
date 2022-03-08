using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CitizenAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField]
    private List<Transform> waypoints;
    public bool reverse = false;
    public int currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if(waypoints.Count > 0 && waypoints[currentTarget] != null)
        {
            _agent.SetDestination(waypoints[currentTarget].position);
        }

        float distance = Vector3.Distance(transform.position, waypoints[currentTarget].position);

        if (distance < 1.0f)
        {
            if (reverse == true)
            {
                currentTarget--; //reversing

                if (currentTarget == 0) // if no more current target = begining
                {
                    reverse = false;
                    currentTarget = 0;
                }
            }

            else if (reverse == false)
            {
                currentTarget++; // incrementing 

                if (currentTarget == waypoints.Count - 1) // at the end of list? 
                {
                    reverse = true;
                    currentTarget--;
                }
            }
        }
    }
       
}
