using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFlash : MonoBehaviour
{
    public GameObject textComponentToFlash;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while(true)
        {
            StartCoroutine(StopThisNow());
            textComponentToFlash.SetActive(true);
            yield return new WaitForSeconds(0.50f);
            textComponentToFlash.SetActive(false);
            yield return new WaitForSeconds(0.50f);

        }
    }

    IEnumerator StopThisNow()
    {
        yield return new WaitForSeconds(2.0f);
        this.gameObject.SetActive(false);
    }
}
