using UnityEngine;

public class Player : MonoBehaviour
{
    public SkillSO[] skillsArray;

    public bool IsSkillInPlayerArray(Skill skillToCheck)
    {
        foreach (SkillSO skill in skillsArray)
        {
            if (skill.skill == skillToCheck)
            {
                return true; // Skill found in player.skillsArray
            }
        }
        return false; // Skill not found in player.skillsArray
    }
}
