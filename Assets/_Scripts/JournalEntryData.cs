using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class JournalEntryData
{
    public DateTime Date{get; set;}
    public string Question{get;set;}
    public int AvatarIndex{get;set;}
    public List<Note> Comments{get; set;}
}
