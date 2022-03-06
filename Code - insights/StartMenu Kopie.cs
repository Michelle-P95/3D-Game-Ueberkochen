using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    GameObject menu;
    GameObject helpUI;
    GameObject settingsUI;
    // Sprechblase UI
    GameObject rezepteUI;
    GameObject steuerungUI;
    GameObject infoUI;

    GameObject musicON;
    GameObject musicOFF;

    public static bool musicIsOn = true;
    AudioSource sound;

    void Start() {
        menu = GameObject.FindGameObjectWithTag("UI_StartMenu");
        helpUI = GameObject.FindGameObjectWithTag("UI_Help");
        settingsUI = GameObject.FindGameObjectWithTag("UI_Settings");
        //musicON = GameObject.FindGameObjectWithTag("ON");
        //musicOFF = GameObject.FindGameObjectWithTag("OFF");
        rezepteUI = GameObject.FindGameObjectWithTag("UI_Rezepte");
        steuerungUI = GameObject.FindGameObjectWithTag("UI_Steuerung");
        infoUI = GameObject.FindGameObjectWithTag("UI_Info");

        menu.SetActive(true);
        helpUI.SetActive(false);
        settingsUI.SetActive(false);
        rezepteUI.SetActive(false);
        steuerungUI.SetActive(false);
        infoUI.SetActive(false);

        //sound = GetComponent<AudioSource>();
        //sound.Play();

    }

    void Update() {
    }

    public void Chillig() {
        //Debug.Log("Das Startmenu übergibt dem Game: " + MusicIsOn);
        SceneManager.LoadScene("Chillig");
        Time.timeScale = 1f;
    }

    public void Stressig() {
        SceneManager.LoadScene("Stressig");
        Time.timeScale = 1f;
    }

    public void Help() {
        helpUI.SetActive(true);
    }

    public void CloseHelp(){
        helpUI.SetActive(false);
        rezepteUI.SetActive(false);
        steuerungUI.SetActive(false);
        infoUI.SetActive(false);
    }

    public void BackToHelp() {
        helpUI.SetActive(true);
        rezepteUI.SetActive(false);
        steuerungUI.SetActive(false);
        infoUI.SetActive(false);
    }

    public void Steuerung() {
        steuerungUI.SetActive(true);
    }

    public void Rezepte() {
        rezepteUI.SetActive(true);
    }

    public void Info() {
        infoUI.SetActive(true);
    }

    public void Quit() {
        Application.Quit();
    }

    public void Settings() {
        settingsUI.SetActive(true);
        menu.SetActive(false);
    }

    // Settings & Help UIS
    public void Home() {
        settingsUI.SetActive(false);
        helpUI.SetActive(false);
        menu.SetActive(true);
    }
/*
    public void Music()
    {
        if(musicIsOn) {
            // Musik an -> also ausschalten
            SetMusicStatus(false);
        }
        else {
            // Musik aus -> also anschalten
            SetMusicStatus(true);
        }
    }

    public void SetMusicStatus(bool statusMusicOn){
        
        if (statusMusicOn) {            // Musik ist an
            musicIsOn = true;
            sound.mute = false;
            musicON.SetActive(true);
            musicOFF.SetActive(false);
        }
        else {                          // Musik ist aus
            musicIsOn = false;
            sound.mute = true;
            musicON.SetActive(false);
            musicOFF.SetActive(true);
        }
        
    }
*/
    public static bool MusicIsOn { 
        get { return musicIsOn; }
    }

}

   