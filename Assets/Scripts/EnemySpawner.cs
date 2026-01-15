using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemyWave> wavesList;
    public float delayBetweenWaves = 3f;
    
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    public IEnumerator SpawnWave()
    {
        while(true)
        {
            var currentWave = wavesList[Random.Range(0, wavesList.Count)];
            
            foreach(GameObject enemy in currentWave.enemiesInWave)
            {
                Instantiate(enemy, transform);
                yield return new WaitForSeconds(currentWave.waitTime);
            }
            
            yield return new WaitForSeconds(delayBetweenWaves);
        }
    }
}
