using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E8508 : Entry
{
    [SerializeField] int entryID;

    [TextArea(3, 20)]
    [SerializeField] string bodyText1;

    List<PlayerChoice> choices;

    [TextArea(2, 20)]
    [SerializeField] string[] responses;

    public void Awake()
    {
        base.EntryID = entryID;
    }

    public override void OnEntryLoad(StoryManager sm)
    {
        base.OnEntryLoad(sm);

        sm.UpdateMainText(bodyText1);
        sm.spManager.MarkStoryPoint("H1");
        sm.spManager.MarkStoryPoint("Z2");

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        if (sm.timeKeeper.TimePassed >= 2)
        {
            PlayerChoice c1 = new PlayerChoice(7094, responses[choices.Count]);
            choices.Add(c1);
        }
        else
        {
            PlayerChoice c2 = new PlayerChoice(7616, responses[choices.Count]);
            choices.Add(c2);
        }
    }
}