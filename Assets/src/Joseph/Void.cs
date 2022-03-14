using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
   public int triggered = 0;
   public int scene;
   public int damage = -5;

   // Start is called before the first frame update
   void Start(){}
   // Update is called once per frame
   void Update(){}

   void OnTriggerStay2D(Collider2D other)
   {
      triggered=1;
      Vector2 position = new Vector2(0f,0f);
      PlayerClass player = PlayerClass.Instance;
      if(other.name != "Player")
      {
         return;
      }

      //Move Player to the start of the level
      if(scene == 2)
      {
         position.x = -9f;
         position.y = 3.75f;
         player.setPlayerPos(position);
      }
      //Damage the player
      player.updateHealth(damage);
   }

   void OnTriggerExit2D(Collider2D other)
   {
      triggered=0;
   }
}