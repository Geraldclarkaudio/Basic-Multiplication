using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroid;

    private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }


    IEnumerator Spawn()
    {
        while(true)
        {
            Instantiate(asteroid, new Vector3(-11898, Random.Range(530, -3000), Random.Range(4000, 31)), Quaternion.identity);
            yield return new WaitForSeconds(2f);

        }
    }
}
