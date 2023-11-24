using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1513 : Entry
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

        if(sm.player.SkillInPlayerArray(Skill.Brawling) || sm.player.SkillInPlayerArray(Skill.Willpower))
        {
            PlayerChoice c1 = new PlayerChoice(8563, "Continue...");
            choices.Add(c1);
        }
        else
        {
            PlayerChoice c2 = new PlayerChoice(4384, "Continue...");
            choices.Add(c2);
        }
    }
}
