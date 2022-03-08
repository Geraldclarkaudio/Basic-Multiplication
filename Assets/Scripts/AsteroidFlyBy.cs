using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFlyBy : MonoBehaviour
{
    private float _speed = 5000f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * _speed * Time.deltaTime);

        if(transform.position.x >= 1000)
        {
            Destroy(this.gameObject);
        }
    }
}
