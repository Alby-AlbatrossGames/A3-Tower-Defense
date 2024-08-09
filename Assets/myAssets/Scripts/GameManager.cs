using System.Collections;
using UnityEngine;

public enum GameState
{
    Attack,
    Build,
    Menu
}
public class GameManager : Singleton<GameManager>
{
    public GameState gState;
    public int curWave = 0;

    private void Start()
    {
        curWave = 1;
    }

    public void StartWave(int _wave)
    {
        StartCoroutine(_EM.SpawnWave(_wave, _wave + 2, 0));
        curWave++;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartWave(curWave);
            Debug.Log("[_GM]:Next Wave Spawned");
        }
            
    }
}
