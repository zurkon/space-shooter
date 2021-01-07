using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    public GameObject enemyPrefab;
    public GameObject pathPrefab;
    public float timeBetweenSpawns = 0.5f;
    // public float spawnRandomFactor = 0.3f;
    public int numberOfEnemies = 5;
    public float moveSpeed = 2f;

    public List<Transform> GetWaypoints()
    {
        List<Transform> waveWaypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }


}
