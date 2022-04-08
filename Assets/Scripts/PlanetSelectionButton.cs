using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetSelectionButton : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    public GameObject fadeOut;


    public void LoadScene()
    {
        fadeOut.SetActive(true);
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(sceneToLoad);
    }

}
