using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WolfBedroomStatsUI : MonoBehaviour
{
    [SerializeField] private WolfHomeController wolf;

    [SerializeField] private Image hpFill;
    [SerializeField] private TMP_Text hpText;

    [SerializeField] private Image sleepyFill;
    [SerializeField] private TMP_Text sleepyText;

    private void Update()
    {
        float hp = wolf.HP;
        hpFill.fillAmount = Mathf.Clamp01(hp / 100f);
        hpText.text = $"{hp:0}%";

        float sleepy = wolf.Sleepy;
        sleepyFill.fillAmount = Mathf.Clamp01(sleepy / 100f);
        sleepyText.text = $"{sleepy:0}%";
    }
} 