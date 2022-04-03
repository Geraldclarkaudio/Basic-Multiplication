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
    public GameObject question2Dialog;
    public GameObject engineBlowout;

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
                engineBlowout.SetActive(true);
                EnableQuestion1();
            }
        }

        if(slider.value == 51)
        {
            //Question 2 Enabled
            question2Dialog.SetActive(true);
        }

        if(slider.value == 26)
        {
            //question3 enabled. 
            //Asteroid storm 
        }

        if(slider.value == 1)
        {
            //closing dialog for this scene. 
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
        question1Dialog.SetActive(true);        
    }

    public void FixEngine()
    {
        engineBlowout.SetActive(false);
    }

}
