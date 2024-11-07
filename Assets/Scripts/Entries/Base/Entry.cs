using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{
    public int EntryID { get; set; }

    public List<PlayerChoice> LinkedChoices { get; set; }

    public virtual void OnEntryLoad(StoryManager sm)
    {
        sm.entryIDText.text = EntryID.ToString();
    }
}