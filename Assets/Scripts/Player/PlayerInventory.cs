using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    public ItemSO item;
    public int quantity;

    public ItemSlot(ItemSO item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}

public class PlayerInventory : MonoBehaviour
{
    public List<ItemSlot> itemSlots = new List<ItemSlot>();

    [SerializeField] ItemSO[] itemArray;
    public Dictionary<char, ItemSO> itemDictionary = new Dictionary<char, ItemSO>();

    private void Start()
    {
        InitializeInventory();
    }

    public void InitializeInventory()
    {
        itemDictionary.Clear();

        foreach (ItemSO item in itemArray)
        {
            itemDictionary[item.itemID] = item;
        }
    }

    public void AddItem(char itemID, int quantity)
    {
        if (itemDictionary.TryGetValue(itemID, out ItemSO item))
        {
            // Check if the item is already in the inventory
            ItemSlot existingSlot = itemSlots.Find(slot => slot.item == item);

            if (existingSlot != null)
            {
                existingSlot.quantity += quantity;
            }
            else
            {
                // Add a new slot
                itemSlots.Add(new ItemSlot(item, quantity));
            }
        }
        else
        {
            Debug.LogWarning($"Item with ID {itemID} not found.");
        }
    }

    public void RemoveItem(char itemID, int quantity)
    {
        if (itemDictionary.TryGetValue(itemID, out ItemSO item))
        {
            ItemSlot existingSlot = itemSlots.Find(slot => slot.item == item);

            if (existingSlot != null)
            {
                existingSlot.quantity -= quantity;

                // Remove the slot if the quantity becomes zero
                if (existingSlot.quantity <= 0)
                {
                    itemSlots.Remove(existingSlot);
                }
            }
        }
        else
        {
            Debug.LogWarning($"Item with ID {itemID} not found.");
        }
    }
}
