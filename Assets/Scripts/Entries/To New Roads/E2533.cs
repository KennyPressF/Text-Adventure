using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class E2533 : Entry
{
    [SerializeField] int entryID;

    [TextArea(3, 20)]
    [SerializeField] string bodyText1;

    [TextArea(3, 20)]
    [SerializeField] string bodyText2;

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

        bool playerHasSkill = false;
        foreach (Skill skill in new Skill[] { Skill.Athletics, Skill.Endurance })
        {
            if (sm.player.SkillInPlayerArray(skill))
            {
                playerHasSkill = true;
                break;
            }    
        }
        if(playerHasSkill == false) { sm.UpdateStamina(2, false); }

        sm.UpdateMainText(bodyText2);

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        PlayerChoice c1 = new PlayerChoice(5129, responses[choices.Count]);
        choices.Add(c1);
    }
}
