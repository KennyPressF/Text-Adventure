using System.Collections.Generic;
using UnityEngine;

public class E1096 : Entry
{
    [SerializeField] int entryID;

    [TextArea(3, 20)]
    [SerializeField] string bodyText1;

    [TextArea(3, 20)]
    [SerializeField] string bodyText2;

    List<PlayerChoice> choices;

    [TextArea(2, 20)]
    [SerializeField] string[] responses;

    protected override void Awake()
    {
        base.Awake();
        base.EntryID = entryID;
    }

    public override void OnEntryLoad(StoryManager sm)
    {
        base.OnEntryLoad(sm);

        sm.UpdateMainText(bodyText1);
        sm.UpdateTime(2);
        sm.UpdateStamina(2, true);
        sm.UpdateMainText(bodyText2);

        PopulateChoices(sm);
        sm.UpdateButtons(choices);
    }

    private void PopulateChoices(StoryManager sm)
    {
        choices = new List<PlayerChoice>();

        PlayerChoice c1 = new PlayerChoice(3123, responses[choices.Count]);
        choices.Add(c1);

        PlayerChoice c2 = new PlayerChoice(1654, responses[choices.Count]);
        choices.Add(c2);

        PlayerChoice c3 = new PlayerChoice(8267, responses[choices.Count]);
        choices.Add(c3);
    }
}