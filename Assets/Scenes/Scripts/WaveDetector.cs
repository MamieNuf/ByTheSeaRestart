using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDetector : MonoBehaviour
{
    public bool isInWaveZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("WaterUser"))
        {
            isInWaveZone = true;
            Debug.Log($"{gameObject.name} est dans une vague.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("WaterUser"))
        {
            isInWaveZone = false;
            Debug.Log($"{gameObject.name} n'est plus dans une vague.");
        }
    }
}



