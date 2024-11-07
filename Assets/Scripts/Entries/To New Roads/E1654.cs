using System.Collections.Generic;
using UnityEngine;

public class E1654 : Entry
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
        sm.spManager.MarkStoryPoint("X1");
        sm.UpdateMainText(bodyText2);

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        PlayerChoice c1 = new PlayerChoice(9943, responses[choices.Count]);
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(7686, responses[choices.Count]);
        choices.Add(c2);

        PlayerChoice c3 = new PlayerChoice(8408, responses[choices.Count], new Skill[] { Skill.Stealth });
        choices.Add(c3);
    }
}
