using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3549 : Entry
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
        sm.UpdateMainText(bodyText1);

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        PlayerChoice c1 = new PlayerChoice(2172, responses[choices.Count], new Skill[] { Skill.Arcana, Skill.Devotion, Skill.Deception });
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(4017, responses[choices.Count], new Skill[] { Skill.Empathy, Skill.Persuasion });
        choices.Add(c2);

        PlayerChoice c3 = new PlayerChoice(3729, responses[choices.Count], new Skill[] { Skill.Agility, Skill.Athletics });
        choices.Add(c3);

        PlayerChoice c4 = new PlayerChoice(3562, responses[choices.Count]);
        choices.Add(c4);
    }
}
