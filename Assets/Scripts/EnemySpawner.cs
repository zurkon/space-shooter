using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<WaveConfig> waveConfigList;
    int waveIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        WaveConfig currentWave = waveConfigList[waveIndex];
        StartCoroutine(SpawnEnemyWave(currentWave));
    }

    private IEnumerator SpawnEnemyWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.numberOfEnemies; i++)
        {
            Instantiate(
                waveConfig.enemyPrefab,
                waveConfig.GetWaypoints()[waveIndex].transform.position,
                Quaternion.identity
                );
            yield return new WaitForSeconds(waveConfig.timeBetweenSpawns);
        }
    }
}
