using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SkillSO[] skillsArray;

    public bool SkillInPlayerArray(Skill? skillToCheck)
    {
        foreach (var skill in skillsArray)
        {
            if (skill.skill == skillToCheck)
            {
                return true; // Skill found in player.skillsArray
            }
        }
        return false; // Skill not found in player.skillsArray
    }
}
