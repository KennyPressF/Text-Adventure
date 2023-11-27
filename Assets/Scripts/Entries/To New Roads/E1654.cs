using System.Collections;
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

    public void Awake()
    {
        base.EntryID = entryID;
    }

    public override void OnEntryLoad(StoryManager sm)
    {
        sm.UpdateMainText(bodyText1);
        sm.spManager.MarkStoryPoint("X1");
        sm.UpdateMainText(bodyText2);

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        PlayerChoice c1 = new PlayerChoice(9943, "Shout a warning to your traveling companions.");
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(7686, "Draw your weapon and engage the bandits.");
        choices.Add(c2);

        Skill[] reqSkills = new Skill[] { Skill.Stealth };
        PlayerChoice c3 = new PlayerChoice(8408, "Sneak up on the bandits and ambush them.", reqSkills);
        choices.Add(c3);
    }
}
