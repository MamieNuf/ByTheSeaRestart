using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System; // Pour utiliser Action

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage; // Référence à l'image pour le fondu
    public float fadeDuration = 2f; // Durée de la transition
    public string nextSceneName; // Scène suivante à charger

    public static Action OnFadeInComplete; // Événement déclenché quand FadeIn est terminé

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void TransitionToNextScene()
    {
        StartCoroutine(FadeOut(nextSceneName));
    }

    private IEnumerator FadeIn()
    {
        float timer = fadeDuration;
        fadeImage.enabled = true; // Assure-toi que l'image est active

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            float alpha = timer / fadeDuration;
            fadeImage.color = new Color(1, 1, 1, alpha); // Transition blanche
            yield return null;
        }

        fadeImage.enabled = false; // Désactive l'image
        OnFadeInComplete?.Invoke(); // Déclenche l'événement
    }

    private IEnumerator FadeOut(string sceneName)
    {
        float timer = 0;
        fadeImage.enabled = true;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = timer / fadeDuration;
            fadeImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
