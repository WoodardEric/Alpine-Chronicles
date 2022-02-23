using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minViableDoor : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D other)
   {
      if(other.collider.tag == "Player" && Input.GetKey("e"))
      {
         Debug.Log("The door appears to be locked.");
      }
   }
}