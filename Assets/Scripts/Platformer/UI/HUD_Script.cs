using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Script : MonoBehaviour
{
    public TMP_Text Score;
    public Slider HealthBar;
    public Score_Script Player_Script;
    void LateUpdate()
    {
        HealthBar.SetValueWithoutNotify(Player_Script.Health / 100.0f);
        Score.SetText(Player_Script.Score.ToString());
    }
}