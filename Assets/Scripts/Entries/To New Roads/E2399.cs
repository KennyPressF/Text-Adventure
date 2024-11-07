using System.Collections.Generic;
using UnityEngine;

public class E2399 : Entry
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

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        PlayerChoice c1 = new PlayerChoice(6738, responses[choices.Count], new Skill[] { Skill.Brawling, Skill.Dueling, Skill.Military });
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(5280, responses[choices.Count], new Skill[] { Skill.Deception, Skill.Performance });
        choices.Add(c2);

        PlayerChoice c3 = new PlayerChoice(9495, responses[choices.Count], new Skill[] { Skill.Alchemy });
        choices.Add(c3);

        PlayerChoice c4 = new PlayerChoice(7804, responses[choices.Count]);
        choices.Add(c4);
    }
}
