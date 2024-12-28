using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
   public TextMeshProUGUI dialogueText;
   public string[] dialogueLines;
   public float typingSpeed = 0.05f;
   
   private int currentLineIndex = 0;

   private AudioManager audioManager;
   
   private void Awake()
   {
      audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
   }

   private void Start()
   {
      StartCoroutine(DisplayDialogue());
   }

   private IEnumerator DisplayDialogue()
   {        
      while (currentLineIndex < dialogueLines.Length)
      {
         yield return StartCoroutine(TypeLine(dialogueLines[currentLineIndex]));
         audioManager.PlaySfx(audioManager.dialogue);
         currentLineIndex++;
         yield return new WaitForSeconds(0.5f); 
      }
      dialogueText.text = "";
   }
   private IEnumerator TypeLine(string line)
   {
      dialogueText.text = "";
      foreach (var letter in line.ToCharArray())
      {
         dialogueText.text += letter;
         yield return new WaitForSeconds(typingSpeed);
      }
   }
}
