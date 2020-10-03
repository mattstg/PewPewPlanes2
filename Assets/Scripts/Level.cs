using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    
    EnemyManager enemyManager;
    public Wave[] waves;
    int currentWave;
    float timeRemainingUntilNextWave;
    bool wavesComplete;
    void Start()
    {
        enemyManager = GameObject.FindObjectOfType<EnemyManager>();
        currentWave = 0;
        timeRemainingUntilNextWave = waves[0].timeToActivate;
    }

    // Update is called once per frame
    void Update()
    {
        if (wavesComplete)
            return;

        timeRemainingUntilNextWave -= Time.deltaTime;
        if(timeRemainingUntilNextWave <= 0)
        {
            StartCoroutine(StartWave(waves[currentWave]));
            currentWave++;

            if (currentWave >= waves.Length)
                WavesComplete();
            else
                timeRemainingUntilNextWave = waves[currentWave].timeToActivate;
        }
    }
      

    IEnumerator StartWave(Wave waveToSpawn)
    {
        for(int i = 0; i < waveToSpawn.spawnPkg.numberToSpawn; i++)
        {
            enemyManager.SpawnEnemyAtLocation(waveToSpawn.spawnPkg);
            yield return new WaitForSeconds(waveToSpawn.spawnPkg.timeSpacing);
        }

    }

    void WavesComplete()
    {
        Debug.Log("Waves complete");
        wavesComplete = true;
    }

}
