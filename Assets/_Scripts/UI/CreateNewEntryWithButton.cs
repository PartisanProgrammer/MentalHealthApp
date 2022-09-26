using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class CreateNewEntryWithButton : MonoBehaviour
{
   public UnityEngine.UI.Button button;
   public Slider slider;
   public TextMeshProUGUI question;
   public JournalController journal;

   void Awake(){
      button = GetComponent<UnityEngine.UI.Button>();
      journal = FindObjectOfType<JournalController>();
   }

   void Start(){
      button.onClick.AddListener(OnClick());
   }

   UnityAction OnClick(){
      return()=> journal.CreateNewEntry(question.text, slider.value);
   }
}
