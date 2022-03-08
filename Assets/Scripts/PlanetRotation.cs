using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    private float _speed = 10f;

    [SerializeField]
    private Vector3 directionToRotate;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(directionToRotate * _speed  * Time.deltaTime); 
    }
}
