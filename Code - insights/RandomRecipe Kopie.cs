using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomRecipe : MonoBehaviour
{
    int random;
    int RecipeNumber = 0;
    int highestRecipeNumber = 8;
    float counter;
    private Vector3 RecipePosition;
    bool flyInChecker;
    public float timeRemaining = 10000;

    public Transform Kaffee;
    public Transform Pizza;
    public Transform Huhn;
    public Transform Ananas;
    public Transform UI;
    public List<Transform> allRecipes;

    private int timerZeit;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Chillig")
        {
            timerZeit = 12;
        }
        else
        {
            timerZeit = 6;
        }

        giveRandom();
        counter = timeRemaining;
        giveRecipe();
    }

    void FixedUpdate()
    {
        // Makes a Timer
        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
        }
        if(timeRemaining <= counter- timerZeit) {
            giveRecipe();
            counter -= timerZeit;
        }
                
        
        //fly in Recipe
        if(allRecipes.Count != 0 && flyInChecker==true && allRecipes[allRecipes.Count-1].transform.position.x >= RecipePosition.x){
            allRecipes[RecipeNumber-1].transform.position = allRecipes[RecipeNumber-1].transform.position + new Vector3(-30,0,0);
        }
        if(allRecipes.Count != 0 && allRecipes[allRecipes.Count-1].transform.position == RecipePosition){
            flyInChecker = false;
            allRecipes[RecipeNumber-1].transform.position = RecipePosition;
        } 
    }

    void giveRecipe(){
        // randomizer for recipes
        giveRandom();
        flyInChecker = true;
        //Debug.Log(random + " " + timeRemaining);
        if(RecipeNumber < highestRecipeNumber){
            switch(random){
                case 1: drawRecipe(Kaffee); break;
                case 2: drawRecipe(Pizza); break;
                case 3: drawRecipe(Huhn); break;
                case 4: drawRecipe(Ananas); break;
            }      
            RecipeNumber++;
        }
    }


    void giveRandom(){
        random = Random.Range(1, 100);
        if(random<25) {random = 1;}else if(random<50){random = 2;}else if(random<75){random = 3;}else{random = 4;}
    }


    void drawRecipe(Transform newRecipeItem){
        Transform newRecipe = Instantiate (newRecipeItem, UI);     
        //newRecipe.transform.position = newRecipe.position + new Vector3(RecipeNumber*180,0,0);
        RecipePosition = newRecipe.position + new Vector3(RecipeNumber*180,0,0);
        newRecipe.transform.position = newRecipe.position + new Vector3(1800,0,0);
        
        allRecipes.Add(newRecipe);
    }

    public bool isRecipeThere(string tag){
        var checker = false;
        foreach(Transform item in allRecipes){
            if(item.CompareTag(tag) && checker==false){
                checker = true;
            }
            if(checker == true) break; 
        }
        return checker;
    }

    public void destroyRecipe(string tag){
        allRecipes[RecipeNumber-1].transform.position = RecipePosition;
        var checker = false;
        int index = 10000;
        foreach(Transform item in allRecipes){
            index = allRecipes.IndexOf(item);
            if(item.CompareTag(tag) && checker==false){
                Transform clone = allRecipes[index];
                allRecipes.RemoveAt(index);
                Destroy(clone.gameObject);
                checker = true;
                break;
            }
        }
        RecipeNumber--;
        if(checker == true && index != 10000) {
            for(int i = index; i<RecipeNumber;i++){
                allRecipes[i].transform.position = allRecipes[i].position - new Vector3(180,0,0); 
            }
        }
    }
    
}
