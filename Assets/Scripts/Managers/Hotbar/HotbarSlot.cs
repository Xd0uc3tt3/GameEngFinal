using UnityEngine;
using TMPro;

public class HotbarSlot : MonoBehaviour
{
    [SerializeField] public string itemName;
    [SerializeField] private TextMeshProUGUI amountText;

    private int count = 0;

    public void AddItem()
    {
        count++;
        amountText.text = "x" + count.ToString();
    }
}
