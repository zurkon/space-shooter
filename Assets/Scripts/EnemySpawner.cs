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
            // Get a Enemy object from ObjectPool
            GameObject newEnemy = ObjectPool.SharedInstance.GetPooledObject(waveConfig.enemyPrefab.tag);
            newEnemy.transform.position = waveConfig.GetWaypoints()[0].transform.position;
            newEnemy.transform.rotation = Quaternion.identity;

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            newEnemy.SetActive(true);

            yield return new WaitForSeconds(waveConfig.timeBetweenSpawns);
        }
    }
}
