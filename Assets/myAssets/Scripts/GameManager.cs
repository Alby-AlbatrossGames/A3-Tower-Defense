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
}
