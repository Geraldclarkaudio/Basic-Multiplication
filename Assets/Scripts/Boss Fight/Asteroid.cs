using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject explosion;
    public float _speed = 5f;

    private Animator main;

    private void Start()
    {
        main = Camera.main.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Single Laser") || other.CompareTag("Double Laser") || other.CompareTag("Player"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }

        if(other.CompareTag("Player"))
        {
            main.SetTrigger("Shake");
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
