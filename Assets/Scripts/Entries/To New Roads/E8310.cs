using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E8310 : Entry
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

        if(sm.player.IsSkillInPlayerArray(Skill.Agility) || sm.player.IsSkillInPlayerArray(Skill.Empathy))
        {
            PlayerChoice c1 = new PlayerChoice(5481, responses[choices.Count]);
            choices.Add(c1);
        }
        else
        {
            PlayerChoice c2 = new PlayerChoice(4956, responses[choices.Count]);
            choices.Add(c2);
        }
    }
}
