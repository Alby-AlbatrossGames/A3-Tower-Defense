using TMPro;
using UnityEngine;

public class ToggleTemp : GameBehaviour
{
    public TMP_Text title;
    public void ToggleGamemode()
    {
        if (_GM.gState == GameState.Attack)
        {
            _GM.gState = GameState.Build;
            title.text = "MODE: Build";
        }
        else if (_GM.gState == GameState.Build)
        {
            _GM.gState = GameState.Attack;
            title.text = "MODE: Attack";
        }
    }
}
