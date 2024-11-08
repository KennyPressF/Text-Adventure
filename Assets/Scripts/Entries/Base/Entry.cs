using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{
    public int EntryID { get; set; }

    public List<PlayerChoice> LinkedChoices { get; set; }

    protected StoryManager StoryManager { get; private set; }

    protected virtual void Awake()
    {
        StoryManager = FindObjectOfType<StoryManager>();
    }

    public virtual void OnEntryLoad(StoryManager sm)
    {
        sm.entryIDText.text = EntryID.ToString();
    }
}