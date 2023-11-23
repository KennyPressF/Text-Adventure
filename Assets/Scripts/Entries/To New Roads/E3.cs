using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3 : Entry
{
    [SerializeField] int entryID;
    [SerializeField] string bodyText;

    public override void Start()
    {
        base.EntryID = entryID;
        base.BodyText = bodyText;
    }

    public override void OnEntryLoad()
    {
        base.OnEntryLoad();
        Debug.Log("test3");
    }
}
