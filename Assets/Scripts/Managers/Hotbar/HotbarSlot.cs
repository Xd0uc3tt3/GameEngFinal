using UnityEngine;
using TMPro;

public class HotbarSlot : MonoBehaviour
{
    [SerializeField] public string itemName;
    [SerializeField] private TextMeshProUGUI amountText;

    private int count = 0;
    private const int maxCount = 10;

    public void AddItem()
    {
        if (count < maxCount)
        {
            count++;
            amountText.text = "x" + count.ToString();
        }
        else
        {
            ServiceHub.Instance.UiManager.ShowMessage($"You can't carry any more {itemName}");
        }
    }
}
