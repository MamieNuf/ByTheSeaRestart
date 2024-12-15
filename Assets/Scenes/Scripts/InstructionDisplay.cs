using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionDisplay : MonoBehaviour
{
    public TextMeshProUGUI instructionText;

    private void Start()
    {
        // Vérifier si instructionText est correctement assigné
        if (instructionText != null)
        {
            Debug.Log("Instruction Text trouvé : " + instructionText.name);
            instructionText.enabled = false; // Cacher le texte au démarrage
        }
        else
        {
            Debug.LogError("Instruction Text n'est pas assigné dans l'inspecteur !");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur est entré dans la zone d'instruction.");
            if (instructionText != null)
            {
                instructionText.enabled = true;
            }
            else
            {
                Debug.LogError("Instruction Text est null dans OnTriggerEnter !");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur a quitté la zone d'instruction.");
            if (instructionText != null)
            {
                instructionText.enabled = false;
            }
            else
            {
                Debug.LogError("Instruction Text est null dans OnTriggerExit !");
            }
        }
    }
}



