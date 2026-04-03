using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    public static HotbarManager Instance { get; private set; }
    [SerializeField] private HotbarSlot[] slots;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(string itemName)
    {
        foreach (var slot in slots)
        {
            if (slot.itemName == itemName)
            {
                slot.AddItem();
                return;
            }
        }
    }
}
