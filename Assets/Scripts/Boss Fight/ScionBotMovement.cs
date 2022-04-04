using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScionBotMovement : MonoBehaviour
{
    public GameObject explosion;
    public float _speed = 5f;

    private MiniScionBots botsSpawner;

    private void Start()
    {
        botsSpawner = GameObject.Find("MiniScionBotSpawner").GetComponent<MiniScionBots>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Single Laser"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            botsSpawner.botsCount--;
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * _speed * Time.deltaTime);

        if (transform.position.x >= 20f)
        {
            Destroy(this.gameObject);
        }
    }
}
