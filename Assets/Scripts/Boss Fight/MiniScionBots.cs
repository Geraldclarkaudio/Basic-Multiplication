using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniScionBots : MonoBehaviour
{
    private bool stopSpawning = false;

    [SerializeField]
    private GameObject asteroidContainer;
    [SerializeField]
    private GameObject miniScionBot;

    public int botsCount = 14;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Asteroid1Spawn());
    }

    IEnumerator Asteroid1Spawn()
    {
        while (stopSpawning == false && botsCount >= 1)
        {
            GameObject newBot = Instantiate(miniScionBot, new Vector3(transform.position.x, Random.Range(-13f, 40f), 0), transform.rotation);

            newBot.transform.parent = asteroidContainer.transform;
            yield return new WaitForSeconds(Random.Range(2.5f, 5f));
        }

    }
}
