using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minViableDoor : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
   {
      if(other.tag == "Player")
      {
         Debug.Log("The door appears to be locked.");
      }
   }
}