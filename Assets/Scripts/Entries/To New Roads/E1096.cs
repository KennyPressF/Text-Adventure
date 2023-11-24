using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class E1096 : Entry
{
    [SerializeField] int entryID;

    [TextArea(3, 20)]
    [SerializeField] string bodyText1;

    [TextArea(3, 20)]
    [SerializeField] string bodyText2;

    List<PlayerChoice> choices;

    public void Awake()
    {
        base.EntryID = entryID;
    }

    public override void OnEntryLoad(StoryManager sm)
    {
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

        PlayerChoice c1 = new PlayerChoice(3123, "Watch for further movement or signs of danger.");
        choices.Add(c1);
        PlayerChoice c2 = new PlayerChoice(1654, "Arm yourself and take a closer look.");
        choices.Add(c2);
        PlayerChoice c3 = new PlayerChoice(8267, "Wake your fellow travelling companions.");
        choices.Add(c3);
    }
}