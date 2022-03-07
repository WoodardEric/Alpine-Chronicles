using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField]
    private NPCDialogue dialogue = null;
    private PlayerClass playerController = null;

    private void Start()
    {
        // Searches the heirarchy for the "Player" and reports an error if the components looking for on the player are not found.
        playerController = PlayerClass.Instance;
        if (playerController == null)
        {
            Debug.LogError("No player class script was found on the player");
            this.gameObject.SetActive(false);
            return;
        }
    }

    public void UnfreezePlayer()
    {
        playerController.isInteracting(false);
    }

    // public void OnInteract()
    // {
    //     dialogue.gameObject.SetActive(true);
    //     dialogue.AdvanceDialog();  // Starts the first part of dialogue, since the dialogue box opens with no text initially
    // }

    public void interact()
    {
        playerController.isInteracting(true);
        dialogue.gameObject.SetActive(true);
        dialogue.AdvanceDialog();  // Starts the first part of dialogue, since the dialogue box opens with no text initially
    }
}
