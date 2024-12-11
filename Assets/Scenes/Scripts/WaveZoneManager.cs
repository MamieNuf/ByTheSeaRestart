using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveZoneManager : MonoBehaviour
{
    // Pour savoir si le personnage est dans la vague
    public bool isCharacterInWaveZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCharacterInWaveZone = true;
            Debug.Log("Le personnage est entré dans une vague.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCharacterInWaveZone = false;
            Debug.Log("Le personnage est sorti de la vague.");
        }
    }
}

