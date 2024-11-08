using System.Collections.Generic;
using UnityEngine;

public class E3645 : Entry
{
    [SerializeField] int entryID;

    [TextArea(3, 20)]
    [SerializeField] string bodyText1;

    [TextArea(3, 20)]
    [SerializeField] string bodyText2;

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
        sm.UpdateTime(1);
        sm.UpdateMainText(bodyText2);

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        PlayerChoice c1 = new PlayerChoice(2533, responses[choices.Count]);
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(5223, responses[choices.Count], new Skill[] { Skill.Archery });
        choices.Add(c2);

        PlayerChoice c3 = new PlayerChoice(3575, responses[choices.Count], new Skill[] { Skill.Survival });
        choices.Add(c3);
    }
}
