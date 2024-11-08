using System.Collections.Generic;
using UnityEngine;

public class E4300 : Entry
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

        PlayerChoice c1 = new PlayerChoice(8803, responses[choices.Count]);
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(1513, responses[choices.Count]);
        choices.Add(c2);

        PlayerChoice c3 = new PlayerChoice(8427, responses[choices.Count], new Skill[] { Skill.Dueling, Skill.Military });
        choices.Add(c3);

        PlayerChoice c4 = new PlayerChoice(3607, responses[choices.Count], new Skill[] { Skill.Arcana, Skill.Runes });
        choices.Add(c4);
    }
}
