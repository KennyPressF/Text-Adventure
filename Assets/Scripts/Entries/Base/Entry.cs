using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{
    public int EntryID { get; set; }
    public string BodyText { get; set; }

    public List<PlayerChoice> LinkedChoices { get; set; }

    public virtual void Start()
    {

    }

    public virtual void OnEntryLoad()
    {
        Debug.Log("testBase");
    }
}
