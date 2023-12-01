using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E6577 : Entry
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

        PlayerChoice c1 = new PlayerChoice(5967, responses[choices.Count]);
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(3792, responses[choices.Count]);
        choices.Add(c2);

        PlayerChoice c3 = new PlayerChoice(6791, responses[choices.Count], new Skill[] { Skill.Archery });
        choices.Add(c3);

        PlayerChoice c4 = new PlayerChoice(9109, responses[choices.Count], new Skill[] { Skill.Runes });
        choices.Add(c4);

        PlayerChoice c5 = new PlayerChoice(1103, responses[choices.Count], new Skill[] { Skill.Reasoning, Skill.Stealth });
        choices.Add(c5);

        PlayerChoice c6 = new PlayerChoice(8249, responses[choices.Count], new Skill[] { Skill.Performance });
        choices.Add(c6);
    }
}
