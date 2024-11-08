using System.Collections.Generic;
using UnityEngine;

public class E3579 : Entry
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

        PlayerChoice c1 = new PlayerChoice(4156, responses[choices.Count]);
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(3715, responses[choices.Count]);
        choices.Add(c2);

        PlayerChoice c3 = new PlayerChoice(3876, responses[choices.Count], new Skill[] { Skill.Alchemy });
        choices.Add(c3);

        PlayerChoice c4 = new PlayerChoice(1942, responses[choices.Count], new Skill[] { Skill.Craftmanship, Skill.Empathy });
        choices.Add(c4);

        PlayerChoice c5 = new PlayerChoice(1902, responses[choices.Count], new Skill[] { Skill.History, Skill.Streetwise });
        choices.Add(c5);

        PlayerChoice c6 = new PlayerChoice(8508, responses[choices.Count], new Skill[] { Skill.Persuasion, Skill.Streetwise });
        choices.Add(c6);
    }
}
