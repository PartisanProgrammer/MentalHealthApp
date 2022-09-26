using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour{
   public User user;
   public InputField inputField;

   void Awake(){
      user = FindObjectOfType<User>();
      inputField = GetComponent<InputField>();
      
   }

   public void SetUserName(){
         user.userData.Name = inputField.text;
   }

   public void SetUserEmail(){
       user.userData.Email = inputField.text;
   }
}
