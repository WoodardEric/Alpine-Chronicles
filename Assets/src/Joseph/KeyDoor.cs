/*
 * Filename: KeyDoor.cs
 * Devoloper: Joseph
 * Purpose: "Open" the door if the player has the correct key
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Summary: Only open the door if the player has the correct key
 *
 * Member Variables:
 * name - string representing the Prefab name of the expected key
 * fog - a game object
 */
public class KeyDoor : Door
{
    public string key;
    public GameObject fog;

    /*
     * Summary: Open the door if the player has the correct key
     */
    override public void Open()
    {
        PlayerClass player = PlayerClass.Instance;
        bool hasKey;

        hasKey = player.inventory.RemoveItem(key);
        if(hasKey)
        {
            this.gameObject.SetActive(false);
            fog.SetActive(false);
            LevelManager.Instance.UpdateLevel(SceneManager.GetActiveScene().buildIndex, fog.name);
            LevelManager.Instance.UpdateLevel(this.name);
            Debug.Log("Open the door");
        }
        else
        {
            Debug.Log("Player is missing the key");
        }
    }
}
