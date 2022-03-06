using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHandle : MonoBehaviour
{
    private Slider cookingSliderHerd;
    private Slider cookingSliderKaffee;
    private Slider cookingSliderAnanas;

    private deactivateSound a;
    private deactivateSound b;
    private deactivateSound c;

    private GameObject AnanasCutted1;
    private GameObject AnanasCutted2;
    // Start is called before the first frame update
    void Start()
    {
        cookingSliderHerd = GameObject.FindGameObjectWithTag("HerdSlider").GetComponent<Slider>();
        cookingSliderKaffee = GameObject.FindGameObjectWithTag("KaffeeSlider").GetComponent<Slider>();
        cookingSliderAnanas = GameObject.FindGameObjectWithTag("AnanasSlider").GetComponent<Slider>();

        a = cookingSliderHerd.gameObject.GetComponent<deactivateSound>();
        b = cookingSliderKaffee.gameObject.GetComponent<deactivateSound>();
        c = cookingSliderAnanas.gameObject.GetComponent<deactivateSound>();

        //cookingSliderHerd = activeAndInactive2[1].GetComponent<Slider>(); 
        if (cookingSliderHerd.gameObject.activeSelf)
        {
            a.SetOn();
            cookingSliderHerd.gameObject.SetActive(false);
        }
        //cookingSliderKaffee = activeAndInactive2[4].GetComponent<Slider>(); 
        if (cookingSliderKaffee.gameObject.activeSelf)
        {
            b.SetOn();
            cookingSliderKaffee.gameObject.SetActive(false);
        }
        //cookingSliderAnanas = activeAndInactive2[0].GetComponent<Slider>(); 
        if (cookingSliderAnanas.gameObject.activeSelf)
        {
            c.SetOn();
            cookingSliderAnanas.gameObject.SetActive(false);
        }

        AnanasCutted1 = GameObject.FindGameObjectWithTag("AnanasCutted1");
        AnanasCutted2 = GameObject.FindGameObjectWithTag("AnanasCutted2");

        AnanasCutted1.SetActive(false);
        AnanasCutted2.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cookingSliderHerd.gameObject.activeSelf)
        {
            cookingSliderHerd.value = cookingSliderHerd.value + 2;
        }
        if (cookingSliderKaffee.gameObject.activeSelf)
        {
            cookingSliderKaffee.value = cookingSliderKaffee.value + 2;
        }
        if (cookingSliderAnanas.gameObject.activeSelf)
        {
            cookingSliderAnanas.value = cookingSliderAnanas.value + 2;
        }


        if (cookingSliderAnanas.value > 250)
        {
            AnanasCutted1.SetActive(false);
            AnanasCutted2.SetActive(true);
        }
    }
}
