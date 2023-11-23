using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1 : Entry
{
    [SerializeField] int entryID;
    [SerializeField] string bodyText;

    List<PlayerChoice> choices = new List<PlayerChoice>();

    public void Awake()
    {
        PopulateChoices();

        base.EntryID = entryID;
        base.BodyText = bodyText;
        base.LinkedChoices = choices;
    }

    public override void OnEntryLoad()
    {
        base.OnEntryLoad();
        Debug.Log("test1");
    }

    private void PopulateChoices()
    {
        PlayerChoice c1 = new PlayerChoice(2, "Load entry 2", Skill.Alchemy);
        choices.Add(c1);
        PlayerChoice c2 = new PlayerChoice(3, "Load entry 3", null);
        choices.Add(c2);
        PlayerChoice c3 = new PlayerChoice(4, "Load entry 4", null);
        choices.Add(c3);
    }
}
