using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    
    void Awake(){
        DontDestroyOnLoad(this);
    }
}
