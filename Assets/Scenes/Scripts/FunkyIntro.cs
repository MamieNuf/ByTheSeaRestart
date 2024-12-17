using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FunkyIntro : MonoBehaviour
{
    public TMP_Text introText; // Référence au TextMeshPro pour l'introduction
    public TMP_Text pressAnyKeyText; // Référence au TextMeshPro pour "Press any key"
    public string nextSceneName = "MainSceneNoorAnimated";

    public float letterSpeed = 0.04f; // Vitesse d'apparition des lettres
    public float delayBeforeText = 1.0f; // Délai avant de démarrer le texte d'introduction
    public float delayAfterIntro = 1.0f; // Délai avant de montrer "Press any key"

    private string story = "Noor always dreamed of the ocean...\n"
                         + "Jump, ride, and groove to the funky beat of the waves!\n"
                         + "Can you keep up?\n\nLet's ride!";

    private bool canProceed = false;

    private void Start()
    {
        introText.text = ""; // Vide le texte d'introduction au départ
        pressAnyKeyText.text = ""; // Assure que "Press any key" est invisible au départ
        StartCoroutine(StartTextAfterDelay());
    }

    private void Update()
    {
        // Passe à la scène suivante si le joueur appuie sur une touche
        if (canProceed && Input.anyKeyDown)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private IEnumerator StartTextAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeText); // Pause avant l'animation de texte
        yield return StartCoroutine(AnimateText()); // Anime le texte d'introduction

        yield return new WaitForSeconds(delayAfterIntro); // Pause avant "Press any key"
        StartCoroutine(BlinkPressAnyKeyText()); // Démarre le clignotement
    }

    private IEnumerator AnimateText()
    {
        foreach (char letter in story.ToCharArray())
        {
            introText.text += letter;
            yield return new WaitForSeconds(letterSpeed);
        }
    }

    private IEnumerator BlinkPressAnyKeyText()
{
    canProceed = true;
    pressAnyKeyText.text = "Press any key to continue";

    float duration = 1.5f; // Durée totale pour un cycle de clignotement (aller-retour)
    float timer = 0f;

    while (true)
    {
        // Calcule un facteur d'opacité avec une interpolation sinusoïdale pour un effet doux
        float alpha = Mathf.Lerp(0.2f, 1f, Mathf.Sin(timer / duration * Mathf.PI));

        // Applique l'opacité au texte
        pressAnyKeyText.color = new Color(pressAnyKeyText.color.r, pressAnyKeyText.color.g, pressAnyKeyText.color.b, alpha);

        timer += Time.deltaTime;
        if (timer > duration) timer = 0f; // Réinitialise pour une boucle continue

        yield return null; // Attend la prochaine frame
    }
}

}
