using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Journal // Handles Journal months
{
    Dictionary<DateTime,JournalMonth> journalMonths = new Dictionary<DateTime,JournalMonth>();
    public Dictionary<DateTime,JournalMonth> JournalMonths { get { return journalMonths; } }
    
    public void AddEntry(JournalMonth data){
        JournalMonths.Add(FormatDate(DateTime.Now),data);
    }
    public void RemoveEntry(DateTime date){
       
        JournalMonths.Remove(FormatDate(date));
    }
    public JournalMonth TryGetCurrentMonth(){
        if(journalMonths.ContainsKey(FormatDate(DateTime.Now))){
            return journalMonths[FormatDate(DateTime.Now)];
        }
        
        var month = new JournalMonth(DateTime.Now.Month.ToString(),DateTime.Now);
        AddEntry(month);
        return month;
    }
    
    
    DateTime FormatDate(DateTime date){
        return new DateTime(date.Month);
    }
}
