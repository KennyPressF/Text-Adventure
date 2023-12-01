using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E9513 : Entry
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

        PlayerChoice c1 = new PlayerChoice(5517, responses[choices.Count]);
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(9250, responses[choices.Count]);
        choices.Add(c2);

        PlayerChoice c3 = new PlayerChoice(5037, responses[choices.Count], new Skill[] { Skill.Alchemy });
        choices.Add(c3);
    }
}
