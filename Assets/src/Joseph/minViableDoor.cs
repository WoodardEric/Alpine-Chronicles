using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minViableDoor : MonoBehaviour, IInteractable
{
   public void interact()
   {
      Debug.Log("The door appears to be locked.");
   }
}