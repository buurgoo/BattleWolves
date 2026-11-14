using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WolfBathStatsUI : MonoBehaviour
{
    [SerializeField] private WolfController wolf;

    [SerializeField] private Image hpFill;
    [SerializeField] private TMP_Text hpText;

    [SerializeField] private Image stinkyFill;
    [SerializeField] private TMP_Text stinkyText;

    private void Update()
    {
        float hp = wolf.HP;
        hpFill.fillAmount = Mathf.Clamp01(hp / 100f);
        hpText.text = $"{hp:0}%";

        float stinky = wolf.Stinky;
        stinkyFill.fillAmount = Mathf.Clamp01(stinky / 100f);
        stinkyText.text = $"{stinky:0}%";
    }
} 