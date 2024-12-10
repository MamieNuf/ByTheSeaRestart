using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class FootGroundDetector : MonoBehaviour
{
    public ThirdPersonController thirdPersonController; // Référence au ThirdPersonController

    private void Update()
    {
        if (thirdPersonController != null)
        {
            // Utiliser la méthode GroundedCheck du ThirdPersonController
            thirdPersonController.GroundedCheck();

            // Vérifier si le personnage est au sol
            if (thirdPersonController.Grounded)
            {
                Debug.Log($"{gameObject.name} est au sol.");
            }
            else
            {
                Debug.Log($"{gameObject.name} n'est pas au sol.");
            }
        }
        else
        {
            Debug.LogError("Référence à ThirdPersonController non attribuée !");
        }
    }
}

