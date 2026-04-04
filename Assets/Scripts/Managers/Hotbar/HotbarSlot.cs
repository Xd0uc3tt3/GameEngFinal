using UnityEngine;
using TMPro;

public class HotbarSlot : MonoBehaviour
{
    [SerializeField] public string itemName;
    [SerializeField] private TextMeshProUGUI amountText;

    private int count = 0;
    private const int maxCount = 10;

    public bool AddItem()
    {
        if (count < maxCount)
        {
            count++;
            amountText.text = "x" + count.ToString();
            return true;
        }
        else
        {
            ServiceHub.Instance.UiManager.ShowMessage($"You can't carry any more {itemName}");
            return false;
        }
    }

    public bool RemoveItem()
    {
        if (count > 0)
        {
            count--;
            amountText.text = "x" + count.ToString();
            return true;
        }
        return false;
    }

    public int GetCount()
    {
        return count;
    }
}
