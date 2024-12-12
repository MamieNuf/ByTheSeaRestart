using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDetector : MonoBehaviour
{
    public bool isInWaveZone; // Si le personnage est dans une vague

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wave"))
        {
            isInWaveZone = true;
            Debug.Log($"{gameObject.name} est dans une vague générée.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wave"))
        {
            isInWaveZone = false;
            Debug.Log($"{gameObject.name} a quitté la vague générée.");
        }
    }
}


