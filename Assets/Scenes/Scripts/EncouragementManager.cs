using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EncouragementManager : MonoBehaviour
{
    public TMP_Text encouragementText; // Référence au TextMeshPro UI
    public float displayDuration = 1f; // Durée d'affichage du message

    private Coroutine currentMessageRoutine;

    // Méthode pour afficher le message
    public void ShowEncouragementMessage(string message)
    {
        if (currentMessageRoutine != null)
        {
            StopCoroutine(currentMessageRoutine);
        }

        currentMessageRoutine = StartCoroutine(DisplayMessageRoutine(message));
    }

    private IEnumerator DisplayMessageRoutine(string message)
    {
        // Affiche le message avec opacité animée
        encouragementText.text = message;
        encouragementText.alpha = 0;

        // Animation d'apparition (fade-in)
        float elapsedTime = 0f;
        while (elapsedTime < 0.5f)
        {
            elapsedTime += Time.deltaTime;
            encouragementText.alpha = Mathf.Lerp(0, 1, elapsedTime / 0.5f);
            encouragementText.rectTransform.localScale = Vector3.Lerp(Vector3.one * 0.8f, Vector3.one, elapsedTime / 0.5f);
            yield return null;
        }

        yield return new WaitForSeconds(displayDuration);

        // Animation de disparition (fade-out)
        elapsedTime = 0f;
        while (elapsedTime < 0.5f)
        {
            elapsedTime += Time.deltaTime;
            encouragementText.alpha = Mathf.Lerp(1, 0, elapsedTime / 0.5f);
            yield return null;
        }
    }
}

