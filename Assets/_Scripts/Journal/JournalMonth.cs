using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class JournalMonth
{
    public string MonthName{ get; set; }
    public DateTime MonthDate{ get; set; }
    public Dictionary<int,JournalWeek> Weeks{ get; set; }
    
    public JournalMonth(string monthName, DateTime date)
    {
        MonthName = monthName;
        MonthDate = new DateTime(date.Month);
        Weeks = new Dictionary<int, JournalWeek>();
    }

    public JournalWeek TryGetCurrentWeek(){
        if (Weeks.ContainsKey(ISOWeek.GetWeekOfYear(DateTime.Now))){
            return Weeks[ISOWeek.GetWeekOfYear(DateTime.Now)];
        }

        var newWeek = new JournalWeek(DateTime.Now);
        Weeks.Add(ISOWeek.GetWeekOfYear(DateTime.Now), newWeek);
        return newWeek;
    }
}