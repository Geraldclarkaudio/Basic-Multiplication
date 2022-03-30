using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Single Laser") || other.CompareTag("Double Laser"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
