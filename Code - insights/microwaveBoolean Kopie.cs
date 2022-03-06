using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microwaveBoolean : MonoBehaviour
{
    private bool isChicken, isPizza, isMaking;
    // Start is called before the first frame update
    void Start()
    {
        isChicken = false;
        isPizza = false;
        isMaking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChicken)
        {
            isMaking = true;
        }
        else if (isPizza)
        {
            isMaking = true;
        }
        else {
            isMaking = false;
        }
    }

    public bool getChicken() {
        return isChicken;
    }
    public bool getPizza()
    {
        return isPizza;
    }

    public bool getMaking() {
        return isMaking;
    }

    public void setChicken(bool x) {
        isChicken = x;
    }

    public void setPizza(bool y) {
        isPizza = y;
    }
}
