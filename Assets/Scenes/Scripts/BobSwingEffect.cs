using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobSwingEffect : MonoBehaviour
{
    public float swingSpeed = 2f; // Vitesse du balancement
    public float swingAngle = 10f; // Angle de rotation max
    private bool isSwinging = false;

    private void Update()
    {
        if (isSwinging)
        {
            float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void StartSwinging()
    {
        isSwinging = true;
    }

    public void StopSwinging()
    {
        isSwinging = false;
        transform.rotation = Quaternion.identity; // Réinitialise la rotation
    }
}
