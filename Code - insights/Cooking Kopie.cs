using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooking : MonoBehaviour
{
    public Slider cookingSlider;
    public float cooking = 0;
    // Start is called before the first frame update
    void Start()
    {
        //cookingSlider.maxValue = 100;
        cookingSlider.value = cooking;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cookingSlider.value = cookingSlider.value+1;
    }
}
