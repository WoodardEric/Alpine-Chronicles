using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
   public void interact()
   {
      Open();
   }
   
   public virtual void Open()
   {
      Debug.Log("The door appears to be locked.");
   }
}