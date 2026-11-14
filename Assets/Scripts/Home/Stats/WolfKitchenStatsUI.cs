using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WolfKitchenStatsUI : MonoBehaviour
{
    [SerializeField] private WolfHomeController wolf;

    [SerializeField] private Image hpFill;
    [SerializeField] private TMP_Text hpText;

    [SerializeField] private Image hungryFill;
    [SerializeField] private TMP_Text hungryText;

    private void Update()
    {
        float hp = wolf.HP;
        hpFill.fillAmount = Mathf.Clamp01(hp / 100f);
        hpText.text = $"{hp:0}%";

        float hungry = wolf.Hungry;
        hungryFill.fillAmount = Mathf.Clamp01(hungry / 100f);
        hungryText.text = $"{hungry:0}%";
    }
} 