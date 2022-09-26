using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalController : MonoBehaviour{
    public Journal journal = new Journal();
    public User user;
    void Awake(){
        DontDestroyOnLoad(this);
    }

    void Start(){
        user = FindObjectOfType<User>();
    }

    public JournalDay CreateDay(){
        JournalDay day = new JournalDay(DateTime.Now.DayOfWeek){
            MoodRatingAverage = 0,
            JournalEntries = new List<JournalEntry>()
        };
        return day;
    }

    public void CreateNewEntry(string question, float rating){
        JournalEntry entry = new JournalEntry(question,rating,user.userData.Avatar);
        journal.TryGetCurrentMonth().TryGetCurrentWeek().TryGetCurrentDay().AddNewEntry(entry);
    }
}
