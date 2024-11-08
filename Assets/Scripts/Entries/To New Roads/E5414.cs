using System.Collections.Generic;
using UnityEngine;

public class E5414 : Entry
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

        PlayerChoice c1 = new PlayerChoice(2091, responses[choices.Count], new Skill[] { Skill.Archery });
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(2981, responses[choices.Count], new Skill[] { Skill.Thievery });
        choices.Add(c2);

        PlayerChoice c3 = new PlayerChoice(2407, responses[choices.Count], new Skill[] { Skill.Arcana });
        choices.Add(c3);
    }
}
