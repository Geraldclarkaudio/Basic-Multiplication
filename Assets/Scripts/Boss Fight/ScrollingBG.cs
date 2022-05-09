using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    [SerializeField]
    private int speed;

    [SerializeField]
    private GameObject backgroundPrefab;

    private Vector3 startPos = new Vector3(-294, 0, 10);
    private Vector3 killPos = new Vector3(171.7f, 0, 0);
    private Vector3 createPos = new Vector3(-50, 0, 0);

    private bool hasSpawned = false;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);

        if(transform.position.x >= -50 & hasSpawned == false)
        {
            Instantiate(backgroundPrefab, startPos, Quaternion.identity);
            hasSpawned = true;
        }
        if(transform.position.x >= 171.7f)
        {
            Destroy(this.gameObject);
        }
    }
}
