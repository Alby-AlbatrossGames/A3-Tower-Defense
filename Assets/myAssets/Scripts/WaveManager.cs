using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    public bool waveOngoing = false;
    public int currentWave = 1;
    private int enemiesToSpawn = 999;
    public int enemiesSpawnedThisWave;
    private int enemiesLeft;

    private void Start()
    {
        currentWave = 1;
        Prep();
    }

    public void BeginWave()
    {
        enemiesSpawnedThisWave = 0;
        waveOngoing = true;
        Debug.Log("Wave [" + currentWave + "] Started");
        enemiesToSpawn = (currentWave + Random.Range(1, currentWave));
        Debug.Log("Spawning [" + enemiesToSpawn + "] Enemies");
        StartCoroutine(_EM.SpawnWave(1, enemiesToSpawn, Random.Range(0, _EM.EnemyPrefabs.Length)));
    }

    public void CheckWaveStatus()
    {
        Debug.LogWarning("Checking Wave Status");
        enemiesLeft = _EM.ActiveEnemies();
        Debug.Log("Enemies Left: " + enemiesLeft);
        Debug.Log("Enemies Spawned: " + enemiesSpawnedThisWave);
        Debug.Log("Enemies To Spawn: " + enemiesToSpawn);
        if (enemiesSpawnedThisWave == enemiesToSpawn)
            if (enemiesLeft <= 0)
                EndWave();
    }

    public void EndWave()
    {
        waveOngoing = false;
        currentWave++;
        _UM.UpdateWaveUI();
        Debug.Log("Wave [" + (currentWave - 1) + "] Ended");
        Debug.Log("Wave [" + currentWave + "] is next");
        _GM.SetMode(GameState.Build);
    }

    private void Prep()
    {
        waveOngoing = false;
    }
}
