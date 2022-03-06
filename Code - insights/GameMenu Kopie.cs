using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject pausenMenu;
    

    [SerializeField] private TextMeshProUGUI textScore;

    [SerializeField] private Score scoreScript;
    [SerializeField] private TimerController timerController;

    float ergebnis;

    bool gameIsPaused = false;

    void Start()
    {
        pausenMenu.SetActive(false);
        winUI.SetActive(false);

        // calculate when to deactivate StartUI -> Line 42
        float ausblenden = 3;
        ergebnis = timerController.t - ausblenden;
        Debug.Log("Ergebnis is: " + ergebnis);

        textScore.text = "";
    }

    void Update() 
    {
        // deactivate StartUI "LETS GO"
        if(timerController.t < ergebnis) 
        {
          startUI.SetActive(false);
        } 
        
        
        // Pause menu
        /*
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            pausenMenu();
        }
        */
        
        
        // Timer is over
        if(timerController.getFinished())
        {
            Time.timeScale = 0;
            textScore.text = scoreScript.getScore().ToString();
            winUI.SetActive(true);
        }
    }

    public void PauseMenu(){       
        Pause();
    }

    public void BackToStartMenu() {
        SceneManager.LoadScene("StartMenu");
    }

    public void Resume()
    {
        pausenMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pausenMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}

