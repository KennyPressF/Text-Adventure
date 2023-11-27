using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2172 : Entry
{
    [SerializeField] int entryID;

    [TextArea(3, 20)]
    [SerializeField] string bodyText1;

    [TextArea(3, 20)]
    [SerializeField] string bodyText2;

    [TextArea(3, 20)]
    [SerializeField] string bodyText3;

    List<PlayerChoice> choices;

    [TextArea(2, 20)]
    [SerializeField] string[] responses;

    public void Awake()
    {
        base.EntryID = entryID;
    }

    public override void OnEntryLoad(StoryManager sm)
    {
        sm.UpdateMainText(bodyText1);
        sm.spManager.MarkStoryPoint("L1");
        sm.UpdateMainText(bodyText2);
        sm.UpdateInventory('B', 1, true);
        sm.UpdateMainText(bodyText3);

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        PlayerChoice c1 = new PlayerChoice(8549, responses[choices.Count]);
        choices.Add(c1);
    }
}
