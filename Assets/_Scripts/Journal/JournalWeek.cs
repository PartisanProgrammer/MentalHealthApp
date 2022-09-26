using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class JournalWeek 
{
    public int WeekNumber{ get; set; }
    public Dictionary<DayOfWeek,JournalDay> Days{ get; set; }

    public JournalWeek(DateTime date)
    {
        WeekNumber = ISOWeek.GetWeekOfYear(date);
        Days = new Dictionary<DayOfWeek,JournalDay>();
    }

    public JournalDay TryGetCurrentDay(){
        if(Days.ContainsKey(DateTime.Now.DayOfWeek)){
           return Days[DateTime.Now.DayOfWeek];
        }
        var newDay = new JournalDay(DateTime.Now.DayOfWeek);
        Days.Add(DateTime.Now.DayOfWeek,newDay);
        return newDay;
    }
}
