using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WolfHallStatsUI : MonoBehaviour
{
    [SerializeField] private WolfController wolf;

    [SerializeField] private Image hpFill;
    [SerializeField] private TMP_Text hpText;

    [SerializeField] private Image bloodthirstFill;
    [SerializeField] private TMP_Text bloodthirstText;

    private void Update()
    {
        float hp = wolf.HP;
        hpFill.fillAmount = Mathf.Clamp01(hp / 100f);
        hpText.text = $"{hp:0}%";

        float bloodthirst = wolf.Bloodthirst;
        bloodthirstFill.fillAmount = Mathf.Clamp01(bloodthirst / 100f);
        bloodthirstText.text = $"{bloodthirst:0}%";
    }
} 