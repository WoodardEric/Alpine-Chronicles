using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairDoor : Door
{
   public float newX;
   public float newY;

   void Start(){}
   void Update(){}

   override public void interact()
   {
      //PlayerClass player = PlayerClass.Instance;
      Vector2 newPosition = new Vector2(newX,newY);
      Debug.Log("Teleporting Player");
      //player.setPlayerPos(newPosition);
   }
}