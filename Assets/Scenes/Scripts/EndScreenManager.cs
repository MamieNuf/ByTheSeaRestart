using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenuScene"; // Nom de la scène du menu principal
    public string gameSceneName = "MainSceneNoorAnimated";   // Nom de la scène du jeu principal

    public void ReplayGame()
    {
        SceneManager.LoadScene(gameSceneName); // Recharge la scène de jeu
    }

    public void QuitGame()
    {
        Debug.Log("Quitter le jeu");
        Application.Quit(); // Quitte l'application
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName); // Retour au menu principal
    }
}


