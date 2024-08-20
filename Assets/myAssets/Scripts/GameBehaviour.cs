using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    protected static EnemyManager _EM { get { return EnemyManager.instance;  } }
    protected static GameManager _GM { get { return GameManager.instance; } }
    protected static WaveManager _WM { get { return WaveManager.instance; } }
    protected static UIManager _UM {  get { return UIManager.instance; } }
    protected static SceneController _SC {  get { return SceneController.instance; } }
    protected static Player _PLAYER { get { return Player.instance; } }

    public bool canBuild => _GM.gState == GameState.Build;
    public bool isAttacking => _GM.gState == GameState.Attack;
}
