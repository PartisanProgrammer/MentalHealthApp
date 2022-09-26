using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class JournalDay
{
    public DayOfWeek Day{ get; set; }
    public float MoodRatingAverage{ get; set; }
    public List<JournalEntry> JournalEntries{ get; set; }
    
    public JournalDay(DayOfWeek day)
    {
        Day = day;
        JournalEntries = new List<JournalEntry>();
        SetMoodRatingAverage();
    }
    
    
    public float SetMoodRatingAverage() //Todo: Should this be here?
    {
        float total = 0;
        foreach (JournalEntry entry in JournalEntries)
        {
            total += entry.MoodRating;
        }
        MoodRatingAverage = total / JournalEntries.Count;
        return MoodRatingAverage;
    }


    public JournalEntry AddNewEntry(JournalEntry entry){
        JournalEntries.Add(entry);
        SetMoodRatingAverage();
        Debug.Log("Added new entry to " + Day + " with mood rating of " + entry.MoodRating);
        return entry;
    }
}
