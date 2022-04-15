using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeBaseButton : MonoBehaviour
{
    public GameObject fadeout;
    public void LoadScene()
    {
        fadeout.SetActive(true);
        StartCoroutine(WaitToLoad());
        //start coroutine 
    }

    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("HomeBase");
    }
}
