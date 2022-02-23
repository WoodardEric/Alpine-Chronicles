using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private NPCDialogue dialogue = null;
    private playerClass playerController = null;

    private void Start()
    {
        // Searches the heirarchy for the "Player" and reports an error if the components looking for on the player are not found.
        playerController = GameObject.Find("Player").GetComponent<playerClass>();
        if (playerController == null)
        {
            Debug.LogError("No player class script was found on the player");
            this.gameObject.SetActive(false);
            return;
        }
    }

    public void UnfreezePlayer()
    {
        playerController.frozen = false;
    }

    public void OnInteract()
    {
        dialogue.gameObject.SetActive(true);
        dialogue.AdvanceDialog();  // Starts the first part of dialogue, since the dialogue box opens with no text initially
    }
}
