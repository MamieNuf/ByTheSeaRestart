using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private bool isInWaveZone = false;

private void OnTriggerEnter(Collider other)
{
    Debug.Log($"OnTriggerEnter: {other.name} entered the wave zone.");
    if (other.name == "Left_ToesEnd" || other.name == "Right_ToesEnd")
    {
        isInWaveZone = true;
        Debug.Log($"Foot detected in wave zone: {other.name}");
    }
}

private void OnTriggerExit(Collider other)
{
    Debug.Log($"OnTriggerExit: {other.name} exited the wave zone.");
    if (other.name == "Left_ToesEnd" || other.name == "Right_ToesEnd")
    {
        isInWaveZone = false;
        Debug.Log($"Foot left the wave zone: {other.name}");
    }
}



    private void Update()
    {
        // Log the state of isInWaveZone for debugging
        Debug.Log($"Is in wave zone: {isInWaveZone}");
    }
}


