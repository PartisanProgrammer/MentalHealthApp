using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{

    public UserData userData = new UserData();

    public void Awake(){
        DontDestroyOnLoad(this);
    }
    
   
}
