using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class JournalEntry
{
    public DateTime Date{get; set;}
    public string Question{get;set;}
    public int AvatarIndex{get;set;}
    public List<Comment> Comments{get; set;}
}
