using System.Collections.Generic;
using UnityEngine;

public class E9109 : Entry
{
    [SerializeField] int entryID;

    [TextArea(3, 20)]
    [SerializeField] string bodyText1;

    List<PlayerChoice> choices;

    [TextArea(2, 20)]
    [SerializeField] string[] responses;

    protected override void Awake()
    {
        base.Awake();
        base.EntryID = entryID;
    }

    public override void OnEntryLoad(StoryManager sm)
    {
        base.OnEntryLoad(sm);

        sm.UpdateMainText(bodyText1);

        if (sm.spManager.IsStoryPointMarked("N3"))
        {
            sm.spManager.MarkStoryPoint("D4");
            sm.spManager.MarkStoryPoint("M3");
        }
        else
        {
            sm.spManager.MarkStoryPoint("C3");
            sm.spManager.MarkStoryPoint("S2");
        }

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        PlayerChoice c1 = new PlayerChoice(9513, responses[choices.Count]);
        choices.Add(c1);
    }
}
