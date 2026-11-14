using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WolfBathStatsUI : MonoBehaviour
{
    [SerializeField] private WolfController wolf;

    [SerializeField] private Image hpFill;
    [SerializeField] private TMP_Text hpText;

    private void Update()
    {
        if (wolf == null) return;
        float hp = wolf.HP;
        hpFill.fillAmount = Mathf.Clamp01(hp / 100f);
        hpText.text = $"{hp:0}%";
    }
} 