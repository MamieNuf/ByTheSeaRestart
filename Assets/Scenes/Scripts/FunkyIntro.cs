using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FunkyIntro : MonoBehaviour
{
    public TMP_Text introText; // Référence au TextMeshPro
    public string nextSceneName = "MainSceneNoorAnimated";
    public float letterSpeed = 0.04f; // Vitesse d'apparition des lettres

    private string story = "Noor always dreamed of the ocean...\n"
                         + "Jump, ride, and groove to the funky beat of the waves!\n"
                         + "Can you keep up?\n\nLet's ride!";

    private void Start()
    {
        StartCoroutine(AnimateText());
    }

    private void Update()
    {
        // Passer à la scène suivante en appuyant sur une touche
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private System.Collections.IEnumerator AnimateText()
    {
        introText.text = "";
        foreach (char letter in story.ToCharArray())
        {
            introText.text += letter;
            yield return new WaitForSeconds(letterSpeed);
        }
    }
}
