using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ausgabe : MonoBehaviour
{
    public Score score;
    public RandomRecipe randomRecipe;
    //private recipeCrafting recipeCrafting;

    private GameObject pizzaRdy;
    private GameObject APizza;
    private GameObject TasseFull;
    private GameObject huhnRdy;

    void OnTriggerEnter(Collider other)
    {
        TasseFull = GameObject.FindGameObjectWithTag("TasseFull");
        pizzaRdy = GameObject.FindGameObjectWithTag("PizzaRdy");
        APizza = GameObject.FindGameObjectWithTag("APizza");
        huhnRdy = GameObject.FindGameObjectWithTag("huhnRdy");

        if(other.gameObject.CompareTag("TasseFull")) {         
            bool isRecipe = randomRecipe.isRecipeThere("CoffeeRecipe");
            if(isRecipe){
                score.increaseScore(10); 
                randomRecipe.destroyRecipe("CoffeeRecipe");
                //recipeCrafting.ausgabeCall();
            }
        }

        if(other.gameObject.CompareTag("PizzaRdy")){
            bool isRecipe = randomRecipe.isRecipeThere("PizzaRecipe");
            if(isRecipe){
                score.increaseScore(10);   
                randomRecipe.destroyRecipe("PizzaRecipe");
                //recipeCrafting.ausgabeCall();
            }
        }

        if(other.gameObject.CompareTag("APizza")){
            bool isRecipe = randomRecipe.isRecipeThere("AnanasRecipe");
            if(isRecipe){
            score.increaseScore(10);   
            randomRecipe.destroyRecipe("AnanasRecipe");
            //recipeCrafting.ausgabeCall();
            }
            
        }

        if(other.gameObject.CompareTag("huhnRdy")){
            bool isRecipe = randomRecipe.isRecipeThere("ChickenRecipe");
            if(isRecipe){
            score.increaseScore(10);   
            randomRecipe.destroyRecipe("ChickenRecipe");
            //recipeCrafting.ausgabeCall();
            }
            
        }
    }
}
