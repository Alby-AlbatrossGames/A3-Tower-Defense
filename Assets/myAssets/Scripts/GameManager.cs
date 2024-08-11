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
        }
            
    }

    void Setup()
    {
        //set player and inventory values to default
        //start at Wave 1
        //start in Build Mode

        SetMode(GameState.Build);
    }

    void SetMode(GameState _state)
    {
        gState = _state;
        switch (gState)
        {
            case GameState.Attack:
                //change to Attack state
                break;
            case GameState.Build:
                //change to Build state
                break;
        }
    }
}
