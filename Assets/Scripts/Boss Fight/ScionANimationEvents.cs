using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScionANimationEvents : MonoBehaviour
{
    private Animator _anim;

    public bool isDialog = false;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();

        StartCoroutine(AnimationSwitches());
    }

    IEnumerator AnimationSwitches()
    {
        while (isDialog == false)
        {
            //Starting the actual Game.
            yield return new WaitForSeconds(7.0f);
            _anim.SetTrigger("Strafe");
            yield return new WaitForSeconds(7.0f);
            _anim.SetTrigger("Strafe");
        }

    }
}
