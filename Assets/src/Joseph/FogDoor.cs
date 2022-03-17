using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogDoor : Door
{
   public GameObject fog;

   override public void open()
   {
	  //Remove associated fog
      Debug.Log("Remove Fog");
      fog.SetActive(false);
      //Open the Door
      this.gameObject.SetActive(false);
   }
}