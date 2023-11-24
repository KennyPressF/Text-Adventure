using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1340 : Entry
{
    [SerializeField] int entryID;

    [TextArea(3, 20)]
    [SerializeField] string bodyText1;

    [TextArea(3, 20)]
    [SerializeField] string bodyText2;

    List<PlayerChoice> choices;

    public void Awake()
    {
        base.EntryID = entryID;
    }

    public override void OnEntryLoad(StoryManager sm)
    {
        sm.UpdateMainText(bodyText1);
        sm.UpdateTime(1);
        sm.UpdateMainText(bodyText2);

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        PlayerChoice c1 = new PlayerChoice(3579, "Continue...", "E7");
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(4945, "Continue...", "N3");
        choices.Add(c2);
    }
}
