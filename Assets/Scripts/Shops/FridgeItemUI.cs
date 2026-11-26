using UnityEngine;
using TMPro;

public class FridgeItemUI : MonoBehaviour
{
    [SerializeField] private HuntingGroundsItems food;
    [SerializeField] private TMP_Text countText;

    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        int count = FridgeInventory.GetCount(food);
        countText.text = $"×{count}";
    }
}