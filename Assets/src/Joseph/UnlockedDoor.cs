using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedDoor : Door
{
   // Start is called before the first frame update
   void Start(){}
   // Update is called once per frame
   void Update(){}

   override public void interact()
   {
      Debug.Log("Open the door");
      Destroy(this);
   }
}
