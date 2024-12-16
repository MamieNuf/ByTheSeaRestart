using System.Collections;
using System.Collections.Generic;
using TMPro; 
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; 

    public TMP_Text scoreText; // Référence au TextMeshPro UI
    public TMP_Text highscoreText;

    public int score = 0; // Score initial
    public int highscore = 0;

    private void Awake () {
        instance = this;
    }

    private void Start()
    {
       highscore = PlayerPrefs.GetInt("highscore", 0);
       scoreText.text = score.ToString() + " points";
       highscoreText.text = "Highscore : " + highscore.ToString();
    }

    public void AddPoints() {
        score += 10;
        scoreText.text = score.ToString() + " points";
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }

}


