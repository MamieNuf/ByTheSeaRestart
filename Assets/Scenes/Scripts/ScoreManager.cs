using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; // Pour gérer les scènes

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText; // Référence au TextMeshPro UI
    public TMP_Text highscoreText;

    public int score = 0; // Score initial
    public EncouragementManager encouragementManager; 
    
    public string endScreenSceneName = "EndScene"; // Nom de la scène d'écran de fin

    private void Awake()
    {
        // Singleton pour s'assurer qu'une seule instance existe
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Chargement du highscore sauvegardé
       
        scoreText.text = score.ToString() + " points";
        
    }

    public void AddPoints()
    {
        score += 10;
        scoreText.text = score.ToString() + " points";

       if (score == 10)
            encouragementManager.ShowEncouragementMessage("Nice Start!");
        else if (score == 50)
            encouragementManager.ShowEncouragementMessage("You're on Fire!");
        else if (score == 90)
            encouragementManager.ShowEncouragementMessage("Almost There!");

        // Vérification du score pour passer à l'écran de fin
        if (score >= 100)
        {
            Debug.Log("Score de 100 atteint, chargement de l'écran de fin !");
            LoadEndScreen();
        }
    }

    private void LoadEndScreen()
    {
        // Chargement de la scène d'écran de fin en utilisant le nom spécifié
        SceneManager.LoadScene(endScreenSceneName);
    }
}
