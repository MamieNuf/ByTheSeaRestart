using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    private void Awake()
    {
        // Vérifie s'il existe déjà une instance de MusicManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Rend ce GameObject persistant
        }
        else
        {
            Destroy(gameObject); // Détruit les doublons
        }
    }
}
