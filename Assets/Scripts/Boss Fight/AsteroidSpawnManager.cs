using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnManager : MonoBehaviour
{
    private bool stopSpawning = false;

    [SerializeField]
    private GameObject asteroidContainer;
    [SerializeField]
    private GameObject asteroid1;
    [SerializeField]
    private GameObject asteroid2;
    [SerializeField]
    private GameObject asteroid3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Asteroid1Spawn());
        StartCoroutine(Asteroid2Spawn());
        StartCoroutine(Asteroid3Spawn());
    }

    IEnumerator Asteroid1Spawn()
    {
        while(stopSpawning == false)
        {
            GameObject newAsteroid = Instantiate(asteroid1, new Vector3(transform.position.x, Random.Range(-13f, 40f), 0), Quaternion.identity);
            newAsteroid.transform.parent = asteroidContainer.transform;
            yield return new WaitForSeconds(Random.Range(2.5f, 5f));
        }

    }
    IEnumerator Asteroid2Spawn()
    {
        while(stopSpawning == false)
        {
            GameObject newAsteroid = Instantiate(asteroid2, new Vector3(transform.position.x, Random.Range(-13f, 40f), 0), Quaternion.identity);
            newAsteroid.transform.parent = asteroidContainer.transform;
            yield return new WaitForSeconds(Random.Range(5f, 7f));
        }
        
    }

    IEnumerator Asteroid3Spawn()
    {
        while (stopSpawning == false)
        {
            GameObject newAsteroid = Instantiate(asteroid3, new Vector3(transform.position.x, Random.Range(-13f, 40f), 0), Quaternion.identity);
            newAsteroid.transform.parent = asteroidContainer.transform;
            yield return new WaitForSeconds(Random.Range(3f, 6f));
        }
        
    }
}
