using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class JournalEntry
{
    public TimeSpan TimeStamp{get;}
    public string Question{get;}
    public Sprite Avatar{get;}
    public float MoodRating{get; private set; }
    public List<Note> Notes{get;}
    
    public JournalEntry(string question, float moodRating, Sprite avatar)
    {
        TimeStamp = DateTime.Now.TimeOfDay; //TODO: FIX
        Question = question;
        MoodRating = moodRating;
        Avatar = avatar;
        Notes = new List<Note>();
    }
    
    public void SetMoodRating(float rating)
    {
        MoodRating = rating;
    }
}
