using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Référence au personnage
    public Vector3 offset = new Vector3(0, 2, -5); // Décalage par rapport au personnage
    public float smoothSpeed = 0.125f; // Vitesse de lissage

    private void LateUpdate()
    {
        if (target == null) return;

        // Calculer la position cible de la caméra
        Vector3 desiredPosition = target.position + offset;

        // Appliquer un mouvement fluide vers la position cible
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Garder la caméra orientée vers l'avant
        transform.LookAt(target.position + Vector3.up * 1.5f); // Ajustez le "1.5f" selon la hauteur de la tête du personnage
    }
}

