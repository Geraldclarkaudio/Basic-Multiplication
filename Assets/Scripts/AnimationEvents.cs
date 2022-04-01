using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private Animator scionMusicAnim;

    // Start is called before the first frame update
    void Start()
    {
        scionMusicAnim = GameObject.Find("ScionBGM").GetComponent<Animator>();
    }

    public void FadeOut()
    {
        scionMusicAnim.SetTrigger("FadeOut");
    }
}
