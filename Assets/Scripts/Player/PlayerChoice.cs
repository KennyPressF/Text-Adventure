public class PlayerChoice
{
    public int LinkedEntryID;
    public string Text;
    public string SPToMark;
    public Skill[] SkillsToCheck;

    public PlayerChoice(int linkedID, string choiceText)
    {
        LinkedEntryID = linkedID;
        Text = choiceText;
    }

    public PlayerChoice(int linkedID, string choiceText, string spToMark)
    {
        LinkedEntryID = linkedID;
        Text = choiceText;
        SPToMark = spToMark;
    }

    public PlayerChoice(int linkedID, string choiceText, Skill[] requiredSkills)
    {
        LinkedEntryID = linkedID;
        Text = choiceText;
        SkillsToCheck = requiredSkills;
    }
}
