using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E8549 : Entry
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

        if (sm.spManager.IsStoryPointMarked("N3"))
        {
            PlayerChoice c1 = new PlayerChoice(3579, responses[0]);
            choices.Add(c1);
        }

        if (sm.spManager.IsStoryPointMarked("E7"))
        {
            PlayerChoice c2 = new PlayerChoice(4945, responses[1]);
            choices.Add(c2);
        }

        PlayerChoice c3 = new PlayerChoice(1096, responses[2], "H3");
        choices.Add(c3);
    }
}
