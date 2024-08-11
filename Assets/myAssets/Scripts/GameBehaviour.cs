using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    protected static EnemyManager _EM { get { return EnemyManager.instance;  } }
    protected static GameManager _GM { get { return GameManager.instance; } }
    protected static WaveManager _WM { get { return WaveManager.instance; } }

    public bool canBuild => _GM.gState == GameState.Build;
    public bool isAttacking => _GM.gState == GameState.Attack;
}
