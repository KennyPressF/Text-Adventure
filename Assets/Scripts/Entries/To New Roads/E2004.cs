using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2004 : Entry
{
    [SerializeField] int entryID;

    [TextArea(3, 20)]
    [SerializeField] string bodyText1;

    List<PlayerChoice> choices;

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

        PlayerChoice c1 = new PlayerChoice(7296, "Rush forward to engage the bandit.");
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(8310, "Brace yourself to recieve the charge.", new Skill[] { Skill.Military });
        choices.Add(c2);

        PlayerChoice c3 = new PlayerChoice(3568, "Flee and attack at range.", new Skill[] { Skill.Arcana, Skill.Archery, Skill.Thievery });
        choices.Add(c3);

        PlayerChoice c4 = new PlayerChoice(4340, "Protect yourself with an alchemical mixture.", new Skill[] { Skill.Alchemy });
        choices.Add(c4);
    }
}
