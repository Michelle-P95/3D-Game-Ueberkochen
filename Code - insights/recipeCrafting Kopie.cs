using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class recipeCrafting : MonoBehaviour
{
    private GameObject pizzaFrozen;
    private GameObject pizzaRdy;
    private GameObject tellerEmpty;
    private GameObject TasseFull;
    private GameObject TasseEmpty;
    private GameObject TasseMaker;
    private GameObject Ananas;
    private GameObject APizza;
    private GameObject AnanasCutted1;
    private GameObject AnanasCutted2;
    private GameObject huhnFrozen;
    private GameObject huhnRdy;
    //private bool knopfdruck;

    private Slider cookingSliderHerd;
    private Slider cookingSliderKaffee;
    private Slider cookingSliderAnanas;
    bool carrying, carryFrozen, carryTeller, carryPizza, carryTasseEmpty, carryTasseFull, cupMaker;
    bool carryAnanas, carryAPizza, carryHuhnFrozen, carryHuhnRdy, pizzamaking, huhnmaking;
    bool actionInput;

    private microwaveBoolean micro;

    int blubscore;
    private Score score;
    AudioSource[] activeAndInactive2;

    private int lMicro;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Chillig")
        {
            lMicro = 700;
        }
        else {
            lMicro = 400;
        }

        micro = GameObject.FindGameObjectWithTag("Herd").GetComponent<microwaveBoolean>();

        Slider[] activeAndInactive = GameObject.FindObjectsOfType<Slider>(true);
        activeAndInactive2 = GameObject.FindObjectsOfType<AudioSource>(true);
        Debug.Log("" + activeAndInactive2[0] + activeAndInactive2[1] + activeAndInactive2[2] + activeAndInactive2[3] + activeAndInactive2[4] + activeAndInactive2[5]);

        GameObject blub = activeAndInactive2[0].gameObject;
        Debug.Log("" + blub);

        sortArray();
        Debug.Log("cookingSliderKaffee = " + cookingSliderKaffee);
        Debug.Log("AnanasCutted1 = " + AnanasCutted1);

        score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Score>();

        pizzaFrozen = GameObject.FindGameObjectWithTag("PizzaFrozen");
        pizzaFrozen.SetActive(false);
        pizzaRdy = GameObject.FindGameObjectWithTag("PizzaRdy");
        pizzaRdy.SetActive(false);
        tellerEmpty = GameObject.FindGameObjectWithTag("TellerEmpty");
        tellerEmpty.SetActive(false);
        TasseFull = GameObject.FindGameObjectWithTag("TasseFull");
        TasseFull.SetActive(false);
        TasseEmpty = GameObject.FindGameObjectWithTag("TasseEmpty");
        TasseEmpty.SetActive(false);

        //TasseMaker = activeAndInactive2[3].gameObject;
        TasseMaker.SetActive(false);

        Ananas = GameObject.FindGameObjectWithTag("Ananas");
        Ananas.SetActive(false);

        //AnanasCutted1 = activeAndInactive2[5].gameObject;
        AnanasCutted1.SetActive(false);
        //AnanasCutted2 = activeAndInactive2[2].gameObject;
        AnanasCutted2.SetActive(false);

        APizza = GameObject.FindGameObjectWithTag("APizza");
        APizza.SetActive(false);
        huhnFrozen = GameObject.FindGameObjectWithTag("huhnFrozen");
        huhnFrozen.SetActive(false);
        huhnRdy = GameObject.FindGameObjectWithTag("huhnRdy");
        huhnRdy.SetActive(false);

        //cookingSlider.gameObject.SetActive(true);
        cookingSliderHerd.value = 0;
        cookingSliderKaffee.value = 0;
        cookingSliderAnanas.value = 0;
        carrying = false;
        carryFrozen = false;
        carryTeller = false;
        carryPizza = false;
        carryTasseEmpty = false;
        carryTasseFull = false;
        cupMaker = false;
        carryAnanas = false;
        carryAPizza = false;
        carryHuhnFrozen = false;
        carryHuhnRdy = false;
        pizzamaking = false;
        huhnmaking = false;

        blubscore = 0;

        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");

        //knopfdruck = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        blubscore = score.getScore();
    }

    /*public void SetTrue() 
    {
        knopfdruck = true;
    }
    public void SetFalse()
    {
        knopfdruck = false;
    }*/

    private void OnTriggerStay(Collider other) {
        //Basic Items 

        
        if (other.CompareTag("Fridge") && carrying == false && actionInput)
        {
            pizzaFrozen.SetActive(true);
            carryFrozen = true;
            carrying = true;
        }
        if (other.CompareTag("FridgeHuhn") && carrying == false && actionInput)
        {
            huhnFrozen.SetActive(true);
            carryHuhnFrozen = true;
            carrying = true;
        }
        if (other.CompareTag("AnanasBox") && carrying == false && actionInput)
        {
            Ananas.SetActive(true);
            carryAnanas = true;
            carrying = true;
        }
        if (other.CompareTag("Teller") && carrying == false && actionInput)
        {
            tellerEmpty.SetActive(true);
            carryTeller = true;
            carrying = true;
        }
        if (other.CompareTag("Tasse") && carrying == false && actionInput)
        {
            TasseEmpty.SetActive(true);
            carryTasseEmpty = true;
            carrying = true;
        }
        //################################################################
        // craft stations starting
        if (other.CompareTag("Brett") && carryAnanas == true && actionInput)
        {
            Ananas.SetActive(false);
            AnanasCutted1.SetActive(true);
            cookingSliderAnanas.gameObject.SetActive(true);
            carryAnanas = false;
            carrying = false;
        }
        if (other.CompareTag("Herd") && carryFrozen == true && cookingSliderHerd.value < 2 && micro.getMaking() == false && actionInput)
        {
            pizzaFrozen.SetActive(false);
            cookingSliderHerd.gameObject.SetActive(true);
            carryFrozen = false;
            carrying = false;
            micro.setPizza(true);
        }
        if (other.CompareTag("Herd") && carryHuhnFrozen == true && cookingSliderHerd.value < 2 && micro.getMaking() == false && actionInput)
        {
            huhnFrozen.SetActive(false);
            cookingSliderHerd.gameObject.SetActive(true);
            carryHuhnFrozen = false;
            carrying = false;
            micro.setChicken(true);
        }
        if (other.CompareTag("Coffee") && carryTasseEmpty == true && cupMaker == false && actionInput)
        {
            TasseEmpty.SetActive(false);
            cookingSliderKaffee.gameObject.SetActive(true);
            TasseMaker.gameObject.SetActive(true);
            cupMaker = true;
            carryTasseEmpty = false;
            carrying = false;
        }
        //################################################################
        // craft stations finished
        if (cookingSliderAnanas.value == 500 && other.CompareTag("Brett") && carryPizza == true && actionInput)
        {
            APizza.SetActive(true);
            cookingSliderAnanas.gameObject.SetActive(false);
            pizzaRdy.SetActive(false);
            AnanasCutted2.SetActive(false);
            carryPizza = false;
            carryAPizza = true;
            carrying = true;
            cookingSliderAnanas.value = 0;
        }
        if (cookingSliderHerd.value == lMicro && other.CompareTag("Herd") && carryTeller == true && micro.getPizza() == true && actionInput)
        {
            pizzaRdy.SetActive(true);
            cookingSliderHerd.gameObject.SetActive(false);
            tellerEmpty.SetActive(false);
            carryTeller = false;
            carrying = true;
            carryPizza = true;
            cookingSliderHerd.value = 0;
            micro.setPizza(false);
        }
        if (cookingSliderHerd.value == lMicro && other.CompareTag("Herd") && carryTeller == true && micro.getChicken() == true && actionInput)
        {
            huhnRdy.SetActive(true);
            cookingSliderHerd.gameObject.SetActive(false);
            tellerEmpty.SetActive(false);
            carryTeller = false;
            carrying = true;
            carryHuhnRdy = true;
            cookingSliderHerd.value = 0;
            micro.setChicken(false);
        }
        if (cookingSliderKaffee.value == 700 && other.CompareTag("Coffee") && carrying == false && TasseMaker.gameObject.activeSelf && actionInput)
        {
            TasseFull.SetActive(true);
            cookingSliderKaffee.gameObject.SetActive(false);
            TasseMaker.gameObject.SetActive(false);
            carryTasseFull = true;
            carrying = true;
            cupMaker = false;
            cookingSliderKaffee.value = 0;
        }
        //################################################################
        // trashbin
        if (other.CompareTag("Trash") && actionInput && carrying == true)
        {
            ausgabeCall();
            if (blubscore > 9)
            {
                score.decreaseScore(10);
            }
            else {
                score.setZero();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ausgabe") && carrying == true)
        {
            ausgabeCall();
        }
    }

    /*
    private void OnTriggerEnter(Collider other) {
                if (other.CompareTag("Trash") && blubscore > 9 && actionInput){
                score.decreaseScore(10);
                }
                if (other.CompareTag("Trash") && blubscore < 10 && actionInput){
                score.setZero();
                }
            }
     */

    public void ausgabeCall(){
            pizzaFrozen.SetActive(false);
            pizzaRdy.SetActive(false);
            tellerEmpty.SetActive(false);
            TasseFull.SetActive(false);
            TasseEmpty.SetActive(false);
            Ananas.SetActive(false);
            APizza.SetActive(false);
            huhnFrozen.SetActive(false);
            huhnRdy.SetActive(false);
            carrying = false;
            carryFrozen = false;
            carryTeller = false;
            carryPizza = false;
            carryTasseEmpty = false;
            carryTasseFull = false;
            carryAnanas = false;
            carryAPizza = false;
            carryHuhnFrozen = false;
            carryHuhnRdy = false;
    }

    void sortArray(){

        //pls dont look at this

        if(activeAndInactive2[0].gameObject.name == "AnanasTimerChild"){
            cookingSliderAnanas = activeAndInactive2[0].GetComponent<Slider>(); 
        }else if(activeAndInactive2[0].gameObject.name == "HerdTimerChild"){
            cookingSliderHerd = activeAndInactive2[0].GetComponent<Slider>(); 
        }else if(activeAndInactive2[0].gameObject.name == "CoffeeTimerChild"){
            cookingSliderKaffee = activeAndInactive2[0].GetComponent<Slider>(); 
        }else if(activeAndInactive2[0].gameObject.name == "TasseMaker"){
            TasseMaker = activeAndInactive2[0].gameObject;
        }else if(activeAndInactive2[0].gameObject.name == "AnanasCutted1"){
            AnanasCutted1 = activeAndInactive2[0].gameObject;
        }else if(activeAndInactive2[0].gameObject.name == "AnanasCutted2"){
            AnanasCutted2 = activeAndInactive2[0].gameObject;
        }

        if(activeAndInactive2[1].gameObject.name == "AnanasTimerChild"){
            cookingSliderAnanas = activeAndInactive2[1].GetComponent<Slider>(); 
        }else if(activeAndInactive2[1].gameObject.name == "HerdTimerChild"){
            cookingSliderHerd = activeAndInactive2[1].GetComponent<Slider>(); 
        }else if(activeAndInactive2[1].gameObject.name == "CoffeeTimerChild"){
            cookingSliderKaffee = activeAndInactive2[1].GetComponent<Slider>(); 
        }else if(activeAndInactive2[1].gameObject.name == "TasseMaker"){
            TasseMaker = activeAndInactive2[1].gameObject;
        }else if(activeAndInactive2[1].gameObject.name == "AnanasCutted1"){
            AnanasCutted1 = activeAndInactive2[1].gameObject;
        }else if(activeAndInactive2[1].gameObject.name == "AnanasCutted2"){
            AnanasCutted2 = activeAndInactive2[1].gameObject;
        }

        if(activeAndInactive2[2].gameObject.name == "AnanasTimerChild"){
            cookingSliderAnanas = activeAndInactive2[2].GetComponent<Slider>(); 
        }else if(activeAndInactive2[2].gameObject.name == "HerdTimerChild"){
            cookingSliderHerd = activeAndInactive2[2].GetComponent<Slider>(); 
        }else if(activeAndInactive2[2].gameObject.name == "CoffeeTimerChild"){
            cookingSliderKaffee = activeAndInactive2[2].GetComponent<Slider>(); 
        }else if(activeAndInactive2[2].gameObject.name == "TasseMaker"){
            TasseMaker = activeAndInactive2[2].gameObject;
        }else if(activeAndInactive2[2].gameObject.name == "AnanasCutted1"){
            AnanasCutted1 = activeAndInactive2[2].gameObject;
        }else if(activeAndInactive2[2].gameObject.name == "AnanasCutted2"){
            AnanasCutted2 = activeAndInactive2[2].gameObject;
        }

        if(activeAndInactive2[3].gameObject.name == "AnanasTimerChild"){
            cookingSliderAnanas = activeAndInactive2[3].GetComponent<Slider>(); 
        }else if(activeAndInactive2[3].gameObject.name == "HerdTimerChild"){
            cookingSliderHerd = activeAndInactive2[3].GetComponent<Slider>(); 
        }else if(activeAndInactive2[3].gameObject.name == "CoffeeTimerChild"){
            cookingSliderKaffee = activeAndInactive2[3].GetComponent<Slider>(); 
        }else if(activeAndInactive2[3].gameObject.name == "TasseMaker"){
            TasseMaker = activeAndInactive2[3].gameObject;
        }else if(activeAndInactive2[3].gameObject.name == "AnanasCutted1"){
            AnanasCutted1 = activeAndInactive2[3].gameObject;
        }else if(activeAndInactive2[3].gameObject.name == "AnanasCutted2"){
            AnanasCutted2 = activeAndInactive2[3].gameObject;
        }

        if(activeAndInactive2[4].gameObject.name == "AnanasTimerChild"){
            cookingSliderAnanas = activeAndInactive2[4].GetComponent<Slider>(); 
        }else if(activeAndInactive2[4].gameObject.name == "HerdTimerChild"){
            cookingSliderHerd = activeAndInactive2[4].GetComponent<Slider>(); 
        }else if(activeAndInactive2[4].gameObject.name == "CoffeeTimerChild"){
            cookingSliderKaffee = activeAndInactive2[4].GetComponent<Slider>(); 
        }else if(activeAndInactive2[4].gameObject.name == "TasseMaker"){
            TasseMaker = activeAndInactive2[4].gameObject;
        }else if(activeAndInactive2[4].gameObject.name == "AnanasCutted1"){
            AnanasCutted1 = activeAndInactive2[4].gameObject;
        }else if(activeAndInactive2[4].gameObject.name == "AnanasCutted2"){
            AnanasCutted2 = activeAndInactive2[4].gameObject;
        }

        if(activeAndInactive2[5].gameObject.name == "AnanasTimerChild"){
            cookingSliderAnanas = activeAndInactive2[5].GetComponent<Slider>(); 
        }else if(activeAndInactive2[5].gameObject.name == "HerdTimerChild"){
            cookingSliderHerd = activeAndInactive2[5].GetComponent<Slider>(); 
        }else if(activeAndInactive2[5].gameObject.name == "CoffeeTimerChild"){
            cookingSliderKaffee = activeAndInactive2[5].GetComponent<Slider>(); 
        }else if(activeAndInactive2[5].gameObject.name == "TasseMaker"){
            TasseMaker = activeAndInactive2[5].gameObject;
        }else if(activeAndInactive2[5].gameObject.name == "AnanasCutted1"){
            AnanasCutted1 = activeAndInactive2[5].gameObject;
        }else if(activeAndInactive2[5].gameObject.name == "AnanasCutted2"){
            AnanasCutted2 = activeAndInactive2[5].gameObject;
        }
    }

    public void OnAction(InputAction.CallbackContext rtx) => actionInput = rtx.ReadValueAsButton();
}
