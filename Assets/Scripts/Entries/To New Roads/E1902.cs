using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1902 : Entry
{
    [SerializeField] int entryID;

    [TextArea(3, 20)]
    [SerializeField] string bodyText1;

    List<PlayerChoice> choices;

    public void Awake()
    {
        base.EntryID = entryID;
    }

    public override void OnEntryLoad(StoryManager sm)
    {
        sm.UpdateMainText(bodyText1);
        sm.spManager.MarkStoryPoint("K6");
        sm.spManager.MarkStoryPoint("M3");

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        if (sm.timeKeeper.TimePassed >= 2)
        {
            PlayerChoice c1 = new PlayerChoice(7094, "Continue...");
            choices.Add(c1);
        }
        else
        {
            PlayerChoice c2 = new PlayerChoice(7616, "Continue...");
            choices.Add(c2);
        }
    }
}