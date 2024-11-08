using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    public TimeSheetSO currentTimeSheetSO;
    [SerializeField] TimeSheetSO[] timeSheetsArray;

    private int currentDay;
    public int CurrentDay { get { return currentDay; } }

    private int timePassed;
    public int TimePassed { get { return timePassed; } }

    private int[] timeArray;
    private int maxTimeForDay;

    public void SetNewTimeSheet()
    {
        currentTimeSheetSO = timeSheetsArray[0];

        currentDay = currentTimeSheetSO.Day;
        timeArray = currentTimeSheetSO.TimeArray;
        maxTimeForDay = timeArray.Length;
    }

    public void AdvanceTime(int time)
    {
        timePassed += time;

        if (timePassed > maxTimeForDay) { timePassed = maxTimeForDay; }
    }
}
