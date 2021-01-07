using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawner Props")]
    [Tooltip("List of WaveConfig object")]
    public List<WaveConfig> waveConfigList;
    [Tooltip("The list position from WaveConfigList that EnemySpawner will start from.")]
    public int startingWave = 0;
    public bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigList.Count; waveIndex++)
        {
            WaveConfig currentWave = waveConfigList[waveIndex];
            yield return StartCoroutine(SpawnEnemyWave(currentWave));
        }
    }

    private IEnumerator SpawnEnemyWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.numberOfEnemies; i++)
        {
            GameObject newEnemy = Instantiate(
                waveConfig.enemyPrefab,
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity
                );
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.timeBetweenSpawns);
        }
    }
}
