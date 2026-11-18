using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WolfHallStatsUI : MonoBehaviour
{
    [SerializeField] private WolfHomeController wolf;

    [SerializeField] private Image hpFill;
    [SerializeField] private TMP_Text hpText;

    [SerializeField] private Image bloodthirstFill;
    [SerializeField] private TMP_Text bloodthirstText;

    [SerializeField] private Image hungryFill;
    [SerializeField] private TMP_Text hungryText;

    [SerializeField] private Image sleepyFill;
    [SerializeField] private TMP_Text sleepyText;

    [SerializeField] private Image stinkyFill;
    [SerializeField] private TMP_Text stinkyText;

    private void Update()
    {
        float hp = wolf.HP;
        hpFill.fillAmount = Mathf.Clamp01(hp / 100f);
        hpText.text = $"{hp:0}%";

        float bloodthirst = wolf.Bloodthirst;
        bloodthirstFill.fillAmount = Mathf.Clamp01(bloodthirst / 100f);
        bloodthirstText.text = $"{bloodthirst:0}%";

        float hungry = wolf.Hungry;
        hungryFill.fillAmount = Mathf.Clamp01(hungry / 100f);
        hungryText.text = $"{hungry:0}%";

        float sleepy = wolf.Sleepy;
        sleepyFill.fillAmount = Mathf.Clamp01(sleepy / 100f);
        sleepyText.text = $"{sleepy:0}%";

        float stinky = wolf.Stinky;
        stinkyFill.fillAmount = Mathf.Clamp01(stinky / 100f);
        stinkyText.text = $"{stinky:0}%";
    }
} 