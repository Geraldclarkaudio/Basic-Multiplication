using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScionShip : MonoBehaviour
{
    public Slider slider;
    private MeshRenderer rend;

    private ScionANimationEvents animEvents;

    public GameObject scene1;//first timeline scene 
    public GameObject dialog;

    public GameObject question1Dialog;

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
        animEvents = GetComponent<ScionANimationEvents>();
    }

    private void Update()
    {
        if(scene1.activeInHierarchy == false && dialog.activeInHierarchy == false)
        {
            animEvents.enabled = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Single Laser"))
        {
            slider.value -= 1;
            StartCoroutine(HIT());

            if(slider.value == 76) //Question  1
            {
                EnableQuestion1();
            }
        }

    }

    IEnumerator HIT()
    {
        rend.enabled = false;
        yield return new WaitForSeconds(0.15f);
        rend.enabled = true;
        yield return new WaitForSeconds(0.15f);
        rend.enabled = false;
        yield return new WaitForSeconds(0.15f);
        rend.enabled = true;
        yield return new WaitForSeconds(0.15f);
    }

    public void EnableQuestion1()
    {
        //Start another Dialog then start the asteroid Storm.
        question1Dialog.SetActive(true);
        
    }
}
