using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3607 : Entry
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
        if (!sm.player.SkillInPlayerArray(Skill.Agility)) { sm.UpdateStamina(3, false); }
        sm.UpdateMainText(bodyText2);

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        if(sm.spManager.IsStoryPointMarked("H3"))
        {
            PlayerChoice c1 = new PlayerChoice(6577, responses[choices.Count]);
            choices.Add(c1);
        }
        else
        {
            PlayerChoice c2 = new PlayerChoice(9513, responses[choices.Count]);
            choices.Add(c2);
        }
    }
}
