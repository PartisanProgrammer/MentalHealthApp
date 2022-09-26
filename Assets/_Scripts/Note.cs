using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Note 
{
    public TimeSpan Time{ get; set; }
    public string Text{ get; set; }
    
    public Note(string text)
    {
        Time = DateTime.Now.TimeOfDay;
        Text = text;
    }
}
