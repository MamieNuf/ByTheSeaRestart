using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public SceneTransition sceneTransition; // Référence au gestionnaire de transition


    // Méthode appelée lorsque le bouton Start est cliqué
    public void StartGame()
    {

        Debug.Log("Chargement du jeu...");
        // SceneManager.LoadScene("MainSceneNoorAnimated"); // Remplace par le nom de ta scène principale
        sceneTransition.TransitionToNextScene(); // Remplace par le nom de la scène cible
    }

    // Quitter le jeu (optionnel)
    public void QuitGame()
    {
        Debug.Log("Quitter le jeu.");
        Application.Quit();
    }
}

