using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAvatar : MonoBehaviour{
   public Image avatar;
   public User user;

   void Awake(){
      avatar = GetComponent<Image>();
      user = FindObjectOfType<User>();
   }

   public void SetUserImage(){
      user.userData.Avatar = avatar.sprite;
   }
}
