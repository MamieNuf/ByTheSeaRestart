using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Le joueur {other.name} est entré dans la vague {gameObject.name}.");
            // Vous pouvez ajouter une logique supplémentaire ici, comme déclencher un effet visuel.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Le joueur {other.name} a quitté la vague {gameObject.name}.");
            // Ajouter une autre logique, si nécessaire.
        }
    }
}

