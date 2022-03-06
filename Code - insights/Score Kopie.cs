using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    //public Text scoreText;
    public static int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    public void increaseScore(int points) {
        score += points;
        scoreText.text = "Score: " + score;
    }
    public void decreaseScore(int points) {
        score -= points;
        scoreText.text = "Score: " + score;
    }
    public void setZero(){
        score = 0;
         scoreText.text = "Score: " + score;
    } 
    public int getScore(){
        return score;
    }
    
}
