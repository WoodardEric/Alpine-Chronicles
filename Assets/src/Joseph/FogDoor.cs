using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogDoor : Door
{
   public GameObject fog;
   // Start is called before the first frame update
   void Start(){}
   // Update is called once per frame
   void Update(){}

   override public void interact()
   {
      //Remove associated fog
      Debug.Log("Remove Fog");
      fog.SetActive(false);
      //Open the Door
      this.gameObject.SetActive(false);
   }
}