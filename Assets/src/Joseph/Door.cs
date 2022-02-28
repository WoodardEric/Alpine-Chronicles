using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
   virtual public void interact()
   {
      Debug.Log("The door appears to be locked.");
   }
}