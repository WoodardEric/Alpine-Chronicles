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
 * Member Variables:a
 * scene - integer that determines where the player is teleported to on collision
 * damage - integer that denotes how much damage the player takes when enetering the collider
 */
public class Void : MonoBehaviour
{
    public int damage = -5;
    enum side{TOP, BOTTOM, LEFT, RIGHT}
    public int sideVal;

    /*
	 * Summary: Moves the player to the start of the area and causes damage if the player enters the Void Trigger
	 *
	 * Parameters:
	 * other - the Collider2D that enters the trigger
	 */
    void OnTriggerStay2D(Collider2D other)
    {
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

        if (sideVal == (int) side.TOP)
        {
            position.x = player.transform.position.x;
            position.y = this.transform.position.y + 1.5f;
        }
        else if (sideVal == (int) side.BOTTOM)
        {
            position.x = player.transform.position.x;
            position.y = this.transform.position.y - 1.5f;
        }
        else if (sideVal == (int) side.LEFT)
        {
            position.x = this.transform.position.x - 1.5f;
            position.y = player.transform.position.y;
        }
        else if (sideVal == (int) side.RIGHT)
        {
            position.x = this.transform.position.x + 1.5f;
            position.y = player.transform.position.y;
        }

        //Move Player to the start of the area
        player.SetPlayerPos(position);

        //Damage the player
        player.UpdateHealth(damage);
    }
}