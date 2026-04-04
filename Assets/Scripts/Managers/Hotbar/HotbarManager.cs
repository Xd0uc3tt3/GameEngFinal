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

    public bool AddItem(string itemName)
    {
        foreach (var slot in slots)
        {
            if (slot.itemName == itemName)
            {
                return slot.AddItem();
            }
        }

        return false;
    }

    public bool RemoveItem(string itemName)
    {
        foreach (var slot in slots)
        {
            if (slot.itemName == itemName)
            {
                return slot.RemoveItem();
            }
                
        }
        return false;
    }

    public int GetItemCount(string itemName)
    {
        foreach (var slot in slots)
        {
            if (slot.itemName == itemName)
            {
                return slot.GetCount();
            }
        }

        return 0;
    }
}
