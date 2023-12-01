using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3792 : Entry
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

        if(sm.spManager.IsStoryPointMarked("N3"))
        {
            sm.spManager.MarkStoryPoint("K6");
            sm.spManager.MarkStoryPoint("M3");
        }
        else
        {
            sm.spManager.MarkStoryPoint("S2");
            sm.spManager.MarkStoryPoint("W3");
        }

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        if (sm.player.IsSkillInPlayerArray(Skill.Brawling) || sm.player.IsSkillInPlayerArray(Skill.Devotion) || sm.player.IsSkillInPlayerArray(Skill.Willpower))
        {
            PlayerChoice c1 = new PlayerChoice(6899, responses[choices.Count]);
            choices.Add(c1);
        }
        else
        {
            PlayerChoice c2 = new PlayerChoice(7861, responses[choices.Count]);
            choices.Add(c2);
        }
    }
}
