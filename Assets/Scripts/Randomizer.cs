using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public GameObject eq1;
    public GameObject eq2;
    public GameObject eq3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Randomize()); 
    }

    IEnumerator Randomize()
    {
        while(true)
        {
            eq1.SetActive(true);
            eq2.SetActive(false);
            eq3.SetActive(false);

            yield return new WaitForSeconds(1.0f);
            eq1.SetActive(false);
            eq2.SetActive(true);
            eq3.SetActive(false);

            yield return new WaitForSeconds(1.0f);

            eq1.SetActive(false);
            eq2.SetActive(false);
            eq3.SetActive(true);

            yield return new WaitForSeconds(1.0f);
        }
    }
}
