using System.Collections;
using System.Collections.Generic;
using TMPro; 
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Score initial
    public TMP_Text scoreText; // Référence au TextMeshPro UI

    private void Start()
    {
        // Initialiser le texte avec le score actuel
        UpdateScoreText();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText(); // Mettre à jour l'affichage du score
        Debug.Log($"Score actuel : {score}");
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score : {score}";
        }
        else
        {
            Debug.LogError("Aucune référence au TextMeshPro UI !");
        }
    }
}


