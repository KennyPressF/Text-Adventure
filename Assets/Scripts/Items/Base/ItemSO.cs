using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item", fileName = "New Item SO")]
public class ItemSO : ScriptableObject
{
    public char itemID;

    public string itemName;

    [TextArea(1, 20)]
    public string itemDescription;

    [TextArea(1, 20)]
    public string itemEffects;

    public void UseItem()
    {
        //TODO: implement item effects
    }
}
