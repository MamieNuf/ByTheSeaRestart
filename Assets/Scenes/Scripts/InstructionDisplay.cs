using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionDisplay : MonoBehaviour
{
    public TextMeshProUGUI instructionText; // Référence au texte des instructions

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur entre dans la zone
        if (other.CompareTag("Player"))
        {
            instructionText.enabled = true; // Affiche le texte
            Debug.Log("Joueur sur la platforme");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Vérifie si le joueur sort de la zone
        if (other.CompareTag("Player"))
        {
            instructionText.enabled = false;
            Debug.Log("Joueur sors de la platforme"); // Cache le texte
        }
    }
}

