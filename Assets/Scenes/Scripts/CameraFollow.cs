using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Référence au personnage
    public Vector3 offset = new Vector3(0, 2, -5); // Décalage par rapport au personnage
    public float smoothSpeed = 0.125f; // Vitesse de lissage pour la position
    public float rotationSmoothSpeed = 0.1f; // Vitesse de lissage pour la rotation

    private void LateUpdate()
    {
        if (target == null) return;

        // Calculer la position cible de la caméra basée sur la rotation du personnage
        Vector3 rotatedOffset = target.rotation * offset;

        // Calculer la position cible de la caméra
        Vector3 desiredPosition = target.position + rotatedOffset;

        // Appliquer un mouvement fluide vers la position cible
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Calculer la rotation cible pour regarder le personnage
        Quaternion desiredRotation = Quaternion.LookRotation(target.position + Vector3.up * 1.5f - transform.position);

        // Appliquer un lissage sur la rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothSpeed);
    }
}



