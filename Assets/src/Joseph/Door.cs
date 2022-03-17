using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
   public void interact()
   {
      open();
   }
   
   public virtual void open()
   {
      Debug.Log("The door appears to be locked.");
   }
}