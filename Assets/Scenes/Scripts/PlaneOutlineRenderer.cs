using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlaneOutlineRenderer : MonoBehaviour
{
    public float lineWidth = 0.1f; // Épaisseur de la ligne
    public Material lineMaterial; // Matériau pour le Line Renderer

    private LineRenderer lineRenderer;

    void Start()
    {
        // Ajout automatique du Line Renderer s'il n'existe pas
        lineRenderer = GetComponent<LineRenderer>();

        // Applique le matériau et les propriétés de la ligne
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.loop = true; // Fermer le contour

        // Récupère le Box Collider pour dessiner autour du Plane
        BoxCollider box = GetComponent<BoxCollider>();
        if (box != null)
        {
            Vector3 center = box.center;
            Vector3 size = box.size;

            // Calcule les coins du Box Collider
            Vector3[] corners = new Vector3[5];
            corners[0] = transform.TransformPoint(center + new Vector3(-size.x, 0, -size.z) * 0.5f);
            corners[1] = transform.TransformPoint(center + new Vector3(size.x, 0, -size.z) * 0.5f);
            corners[2] = transform.TransformPoint(center + new Vector3(size.x, 0, size.z) * 0.5f);
            corners[3] = transform.TransformPoint(center + new Vector3(-size.x, 0, size.z) * 0.5f);
            corners[4] = corners[0]; // Fermer la boucle

            lineRenderer.positionCount = corners.Length;
            lineRenderer.SetPositions(corners);
        }
        else
        {
            Debug.LogError("BoxCollider non trouvé sur l'objet !");
        }
    }
}

