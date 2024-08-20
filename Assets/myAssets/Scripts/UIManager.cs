using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public TMP_Text waveText;
    public TMP_Text hpText;
    public TMP_Text card1Type;
    public TMP_Text card1Value;

    private void Start()
    {
        UpdatePlayerUI();
        UpdateWaveUI();
        UpdateCardUI(_PLAYER.deck[0].type.ToString(), _PLAYER.deck[0].value.ToString());
    }
    public void UpdateWaveUI()
    {
        waveText.text = "Wave: " + _WM.currentWave;
    }

    public void UpdatePlayerUI()
    {
        hpText.text = $"HP: {_PLAYER.cHP}";
    }

    public void UpdateCardUI(string _type, string _value)
    {
        card1Type.text = _type;
        card1Value.text = _value;
    }
}
