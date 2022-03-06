using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivateSound : MonoBehaviour
{
    private AudioSource audio; 
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.mute = true;
    }

    public void SetOn() {
        audio.mute = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
