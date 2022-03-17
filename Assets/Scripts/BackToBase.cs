using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToBase : MonoBehaviour
{
    public string homeBaseScene;

    public void BackToHomeBase()
    {
        SceneManager.LoadScene(homeBaseScene);
    }
}
