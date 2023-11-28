using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3568 : Entry
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

        if (sm.player.SkillInPlayerArray(Skill.Agility) || sm.player.SkillInPlayerArray(Skill.Athletics))
        {
            PlayerChoice c1 = new PlayerChoice(5414, responses[choices.Count]);
            choices.Add(c1);
        }
        else
        {
            PlayerChoice c2 = new PlayerChoice(6332, responses[choices.Count]);
            choices.Add(c2);
        }
    }
}