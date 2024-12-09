using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public Transform target; // Le personnage à suivre
    public Vector3 offset = new Vector3(0, 1.5f, -3); // Décalage de la caméra

    void LateUpdate()
    {
        if (target == null) return;

        // Mettre à jour la position de la caméra
        transform.position = target.position + offset;

        // Garder la caméra orientée dans la même direction que le personnage
        transform.rotation = Quaternion.Euler(10, target.eulerAngles.y, 0);
    }
}

