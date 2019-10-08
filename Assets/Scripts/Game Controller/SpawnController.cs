using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveParameters
{
    public int killsNeeded = 10;
    public WaveUnitParameters[] enemyUnitsSpawned;
}

public class WaveUnitParameters
{
    public GameObject unitToSpawn;
    public float percentageOfThisUnitKind;
}

public class SpawnController : MonoBehavior
{
    public WaveParameters[] waveParameters;

    private int currentWave = 0;
    private int currentWaveKills = 0;

    void Start()
    {
        GlobalEvents.OnEnemyDeath += EnemyKilled;
    }

    void Destroy()
    {
        GlobalEvents.OnEnemyDeath -= EnemyKilled;
    }

    private void EnemyKilled(object sender, System.EventArgs e)
    {
        currentWaveKills++;

        if (currentWaveKills >= waveParameters[currentWave].killsNeeded)
        {
            currentWaveKills = 0;
            currentWave++;
            GlobalEvents.OnWaveEnded(this, null);
        }
    }
}