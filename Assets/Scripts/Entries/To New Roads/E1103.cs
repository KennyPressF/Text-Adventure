using System.Collections.Generic;
using UnityEngine;

public class E1103 : Entry
{
    [SerializeField] int entryID;

    [TextArea(3, 20)]
    [SerializeField] string bodyText1;

    [TextArea(3, 20)]
    [SerializeField] string bodyText2;

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

        if (sm.spManager.IsStoryPointMarked("N3"))
        {
            sm.spManager.MarkStoryPoint("H1");
            sm.spManager.MarkStoryPoint("K6");
        }
        else
        {
            sm.spManager.MarkStoryPoint("O3");
            sm.spManager.MarkStoryPoint("W3");
        }

        sm.UpdateMainText(bodyText2);

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
