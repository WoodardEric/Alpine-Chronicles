using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedDoor : Door
{
   override public void Open()
   {
	  Debug.Log("Open the door");
      Destroy(this);
      this.gameObject.SetActive(false);
   }
}