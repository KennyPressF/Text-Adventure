using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoice
{
    public int LinkedEntryID;
    public string Text;
    public Skill? SkillToCheck;

    public PlayerChoice(int linkedID, string choiceText, Skill? requiredSkill)
    {
        LinkedEntryID = linkedID;
        Text = choiceText;
        SkillToCheck = requiredSkill;
    }
}
