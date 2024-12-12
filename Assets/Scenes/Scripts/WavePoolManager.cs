using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject wavePrefab; // Prefab de la vague
    public Transform startPoint; // Point de départ
    public Transform endPoint;   // Point d'arrivée
    public int poolSize = 5;     // Nombre de vagues dans le pool
    public float waveSpeed = 5f; // Vitesse de déplacement des vagues
    public float waveFrequency = 1f; // Fréquence du mouvement sinusoïdal
    public float waveAmplitude = 1f; // Amplitude du mouvement sinusoïdal
    public Material waveMaterial; // Shader/Material à appliquer aux vagues

    private Queue<GameObject> wavePool = new Queue<GameObject>(); // Pool de vagues
    private Dictionary<GameObject, float> waveStartTimes = new Dictionary<GameObject, float>(); // Temps de départ de chaque vague

    void Start()
    {
        // Initialiser le pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject wave = Instantiate(wavePrefab);
            wave.SetActive(false);

            // Appliquer le material spécifié si disponible
            if (waveMaterial != null)
            {
                Renderer waveRenderer = wave.GetComponent<Renderer>();
                if (waveRenderer != null)
                {
                    waveRenderer.material = waveMaterial;
                }
            }

            wavePool.Enqueue(wave);
        }

        // Lancer la première vague
        InvokeRepeating(nameof(SpawnWave), 0f, 2f);
    }

    private void SpawnWave()
    {
        if (wavePool.Count > 0)
        {
            GameObject wave = wavePool.Dequeue();
            wave.transform.position = startPoint.position; // Position initiale
            wave.SetActive(true);
            waveStartTimes[wave] = Time.time; // Enregistrer le temps de départ pour le mouvement sinusoïdal
            wavePool.Enqueue(wave); // Réinsérer dans le pool après utilisation
            Debug.Log($"Vague générée à : {wave.transform.position}");
        }
    }

    void Update()
    {
        foreach (var wave in wavePool)
        {
            if (wave.activeSelf)
            {
                float elapsedTime = Time.time - waveStartTimes[wave];
                float sineOffset = Mathf.Sin(elapsedTime * waveFrequency) * waveAmplitude;

                // Déplacer la vague vers la droite (axe X)
                wave.transform.position += Vector3.right * waveSpeed * Time.deltaTime;

                // Appliquer le mouvement sinusoïdal sur l'axe Y
                wave.transform.position = new Vector3(
                    wave.transform.position.x,
                    startPoint.position.y + sineOffset,
                    wave.transform.position.z
                );

                Debug.Log($"Position actuelle de la vague : {wave.transform.position}");

                // Désactiver la vague si elle dépasse le EndPoint
                if (wave.transform.position.x > endPoint.position.x)
                {
                    wave.SetActive(false);
                    Debug.Log($"Vague désactivée à : {wave.transform.position}");
                }
            }
        }
    }
}




