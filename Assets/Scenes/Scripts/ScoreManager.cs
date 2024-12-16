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
    public int highscore = 0;

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
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " points";
        highscoreText.text = "Highscore : " + highscore.ToString();
    }

    public void AddPoints()
    {
        score += 10;
        scoreText.text = score.ToString() + " points";

        // Sauvegarder le highscore si le score actuel est plus élevé
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
            PlayerPrefs.Save();
        }

        // Vérification du score pour passer à l'écran de fin
        if (score >= 200)
        {
            Debug.Log("Score de 200 atteint, chargement de l'écran de fin !");
            LoadEndScreen();
        }
    }

    private void LoadEndScreen()
    {
        // Chargement de la scène d'écran de fin en utilisant le nom spécifié
        SceneManager.LoadScene(endScreenSceneName);
    }
}
