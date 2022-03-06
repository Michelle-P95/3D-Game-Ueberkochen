using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float t;
    
    private bool finished;
    TextMeshProUGUI textmeshPro;

    void Start(){
        textmeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(!finished){
            t -= Time.deltaTime;
            if (t < 0) {
                Debug.Log("STOOOOOOP the Game");
                finished = true;
            }

            string minutes = ((int)t / 60).ToString();
            float secondsFloat = (t % 60);
            string seconds;

            if(secondsFloat <= 9) seconds = "0" + secondsFloat.ToString("f0");
            else seconds = secondsFloat.ToString("f0");

            textmeshPro.text = minutes + ":" + seconds;
        }
    }

    public bool getFinished() 
    {
        return finished;
    }
}
