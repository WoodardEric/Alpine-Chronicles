/*
 * Filename: Void.cs
 * Developer: Joseph
 * Purpose: Define Void behaviour
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: Move the player to the beginning of the area when entering the Void collider
 *
 * Member Variables:
 * triggered - an integer which is 0 if the player is not in the collider and 1 if they area
 * scene - integer that determines where the player is teleported to on collision
 * damage - integer that denotes how much damage the player takes when enetering the collider
 */
public class Void : MonoBehaviour
{
    public int triggered = 0;
    public int scene;
    public int damage = -5;

    /*
	 * Summary: Moves the player to the start of the area and causes damage if the player enters the Void Trigger
	 *
	 * Parameters:
	 * other - the Collider2D that enters the trigger
	 */
    void OnTriggerStay2D(Collider2D other)
    {
        triggered=1;
        Vector2 position = new Vector2(0f,0f);
        PlayerClass player = PlayerClass.Instance;
	  
        if(other.name != "Player")
        {
            return;
        }

        if(other.isTrigger)
        {
            return;
        }

        //Move Player to the start of the area
        if(scene == 1)
        {
            position.x = -9f;
            position.y = 3.75f;
            player.SetPlayerPos(position);
        }
        else if(scene == 2)
        {
            position.x = 9.125f;
		    position.y = -32.5f;
		    player.SetPlayerPos(position);
        }
        //Damage the player
        player.UpdateHealth(damage);
    }


    /*
	 * Summary: Set triggered to 0
	 *
	 * Parameters:
	 * other - the Collider2D that just exited the trigger
	 */
    void OnTriggerExit2D(Collider2D other)
    {
        triggered=0;
    }
}