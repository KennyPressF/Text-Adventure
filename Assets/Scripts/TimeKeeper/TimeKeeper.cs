using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    public TimeSheetSO currentTimeSheet;
    [SerializeField] TimeSheetSO[] timeSheetsArray;

    private int currentDay;
    public int CurrentDay { get { return currentDay; } }

    private int timePassed;
    public int TimePassed { get { return timePassed; } }

    private int[] timeArray;
    private int maxTimeForDay;

    public void SetNewTimeSheet()
    {
        currentTimeSheet = timeSheetsArray[0];

        currentDay = currentTimeSheet.Day;
        timeArray = currentTimeSheet.TimeArray;
        maxTimeForDay = timeArray.Length;
    }

    public void AdvanceTime(int time)
    {
        timePassed += time;

        if(timePassed > maxTimeForDay) { timePassed = maxTimeForDay; }
    }
}
