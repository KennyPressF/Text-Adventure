using System.Collections.Generic;
using UnityEngine;

public class E4945 : Entry
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

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        PlayerChoice c1 = new PlayerChoice(4897, responses[choices.Count]);
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(4899, responses[choices.Count]);
        choices.Add(c2);

        PlayerChoice c3 = new PlayerChoice(1984, responses[choices.Count], new Skill[] { Skill.Deception, Skill.Performance });
        choices.Add(c3);

        PlayerChoice c4 = new PlayerChoice(4510, responses[choices.Count], new Skill[] { Skill.Empathy, Skill.History });
        choices.Add(c4);

        PlayerChoice c5 = new PlayerChoice(2552, responses[choices.Count], new Skill[] { Skill.History, Skill.Military });
        choices.Add(c5);

        PlayerChoice c6 = new PlayerChoice(7526, responses[choices.Count], new Skill[] { Skill.Awareness, Skill.Thievery });
        choices.Add(c6);
    }
}
