using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage; // Référence à l'image pour le fondu
    public float fadeDuration = 2f; // Durée de la transition
    public string nextSceneName; // Scène suivante à charger (modifiable dans l'inspector)

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
        fadeImage.enabled = true; // S'assurer que l'image est active
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            float alpha = timer / fadeDuration;
            fadeImage.color = new Color(1, 1, 1, alpha); // Transition blanche
            yield return null;
        }
        fadeImage.enabled = false; // Désactive l'image une fois la transition terminée
    }

    private IEnumerator FadeOut(string sceneName)
    {
        float timer = 0;
        fadeImage.enabled = true; // Active l'image pour le fade out
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = timer / fadeDuration;
            fadeImage.color = new Color(1, 1, 1, alpha); // Transition blanche
            yield return null;
        }
        SceneManager.LoadScene(sceneName); // Charge la nouvelle scène
    }
}