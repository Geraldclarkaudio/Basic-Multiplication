using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject explosion;
    public float _speed = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Single Laser") || other.CompareTag("Double Laser"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * _speed * Time.deltaTime);
        
        if(transform.position.x >= 20f)
        {
            Destroy(this.gameObject);
        }
    }
}
