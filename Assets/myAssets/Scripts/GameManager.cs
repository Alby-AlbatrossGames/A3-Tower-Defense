using System.Collections;
using TMPro;
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

    private void Start()
    {
        Setup();
    }
    void Setup()
    {
        //set player and inventory values to default
        //start at Wave 1
        //start in Build Mode

        SetMode(GameState.Build);
    }

    public void SetMode(GameState _state)
    {
        gState = _state;
        switch (gState)
        {
            case GameState.Attack:
                Debug.LogError("Attack Mode");
                _WM.BeginWave();
                break;
            case GameState.Build:
                Debug.LogError("Build Mode");
                //change to Build state
                break;
        }
    }

    public TMP_Text title;
    public void TempToggleGamemode()
    {
        if (gState == GameState.Attack)
        {
            SetMode(GameState.Build);
            title.text = "MODE: Build";
        }
        else if (gState == GameState.Build)
        {
            SetMode(GameState.Attack);
            title.text = "MODE: Attack";
        }
    }
}
