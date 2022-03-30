using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Update is called once per frame

    public float timeToDestroy;
    void Update()
    {
        Destroy(this.gameObject, timeToDestroy);
    }
}
