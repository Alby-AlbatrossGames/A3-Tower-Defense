using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public TMP_Text waveText;
    public void UpdateWaveUI()
    {
        waveText.text = "Wave: " + _WM.currentWave;
    }
}
