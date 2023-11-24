using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPointManager : MonoBehaviour
{
    private Dictionary<string, bool> storyPointsDict = new Dictionary<string, bool>();

    public void InitializeStoryPoints()
    {
        for (char set = 'A'; set <= 'Z'; set++)
        {
            for (int i = 1; i <= 8; i++)
            {
                string storyPoint = set + i.ToString();
                storyPointsDict.Add(storyPoint, false);
            }
        }
    }

    // Function to mark a story point
    public void MarkStoryPoint(string storyPoint)
    {
        if (!storyPointsDict.ContainsKey(storyPoint))
        {
            Debug.LogError("Invalid story point: " + storyPoint);
            return;
        }

        storyPointsDict[storyPoint] = true;
    }

    // Function to unmark a story point
    public void UnmarkStoryPoint(string storyPoint)
    {
        if (!storyPointsDict.ContainsKey(storyPoint))
        {
            Debug.LogError("Invalid story point: " + storyPoint);
            return;
        }

        storyPointsDict[storyPoint] = false;
    }

    // Function to check if a story point is marked
    public bool IsStoryPointMarked(string storyPoint)
    {
        if (!storyPointsDict.ContainsKey(storyPoint))
        {
            Debug.LogError("Invalid story point: " + storyPoint);
            return false;
        }

        return storyPointsDict[storyPoint];
    }
}
