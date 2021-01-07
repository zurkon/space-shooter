using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawner Props")]
    [Tooltip("List of WaveConfig object")]
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
            GameObject newEnemy = Instantiate(
                waveConfig.enemyPrefab,
                waveConfig.GetWaypoints()[waveIndex].transform.position,
                Quaternion.identity
                );
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.timeBetweenSpawns);
        }
    }
}
