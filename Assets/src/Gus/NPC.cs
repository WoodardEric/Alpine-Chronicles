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
