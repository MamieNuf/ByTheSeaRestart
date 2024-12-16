using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollisionDetector : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        // Référence au ScoreManager dans la scène
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("Aucun ScoreManager trouvé dans la scène !");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifiez si l'objet est le joueur
        if (other.CompareTag("Player"))
        {
            // Récupérez le script ThirdPersonController pour vérifier isGrounded
            var playerController = other.GetComponent<StarterAssets.ThirdPersonController>();

            if (playerController != null)
            {
                if (!playerController.Grounded)
                {
                    // Ajouter des points si le joueur saute au-dessus de la vague
                    ScoreManager.instance.AddPoints();
                    Debug.Log("Le joueur a sauté au-dessus de la vague et gagne 10 points !");
                }
                else
                {
                    Debug.Log("Le joueur est au sol et ne gagne pas de points.");
                }
            }
        }
    }
}


