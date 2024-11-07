using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Time Sheet", fileName = "New Time Sheet SO")]
public class TimeSheetSO : ScriptableObject
{
    //Book this timesheet belongs to
    [SerializeField] AdventureBook adventureBook;

    //Specific day within timesheet
    [SerializeField] int day;
    public int Day { get { return day; } }

    //Possible time range for that day
    [SerializeField] int[] timeArray;
    public int[] TimeArray { get { return timeArray; } }

    //"End Of Day" - entry to load after the last time has passed for the day
    [SerializeField] int eodEntry;
    public int EodEntry { get { return eodEntry; } }
}
