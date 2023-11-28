using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4055 : Entry
{
    [SerializeField] int entryID;

    [TextArea(3, 20)]
    [SerializeField] string bodyText1;

    [TextArea(3, 20)]
    [SerializeField] string bodyText2;

    [TextArea(3, 20)]
    [SerializeField] string bodyText3;

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
        if(!sm.player.SkillInPlayerArray(Skill.Athletics)) { sm.UpdateStamina(2, false); }
        sm.UpdateMainText(bodyText2);
        if(!sm.player.SkillInPlayerArray(Skill.Agility)) { sm.UpdateStamina(3, false); }
        sm.UpdateMainText(bodyText3);

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        PlayerChoice c1 = new PlayerChoice(8263, responses[choices.Count]);
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(4724, responses[choices.Count], new Skill[] { Skill.Archery });
        choices.Add(c2);

        PlayerChoice c3 = new PlayerChoice(4293, responses[choices.Count], new Skill[] { Skill.Alchemy });
        choices.Add(c3);

        PlayerChoice c4 = new PlayerChoice(3967, responses[choices.Count], new Skill[] { Skill.Arcana, Skill.Runes });
        choices.Add(c4);
    }
}