using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4184 : Entry
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
        sm.UpdateTime(1);

        if (!sm.player.SkillInPlayerArray(Skill.Athletics))
        {
            sm.UpdateStamina(2, false);
        }
        else
        {
            sm.UpdateStamina(1, false);
        }

        sm.UpdateMainText(bodyText2);
        sm.spManager.MarkStoryPoint("D6");

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        PlayerChoice c1 = new PlayerChoice(8557, responses[choices.Count]);
        choices.Add(c1);
    }
}
