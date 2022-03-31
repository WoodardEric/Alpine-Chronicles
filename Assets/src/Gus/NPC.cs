using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField]
    private NPCDialogue dialogue = null;
    private PlayerClass playerController = null;
    SpriteRenderer sprite;

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

        sprite = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerController.transform.position.y > this.transform.position.y - 0.5)
        {
            sprite.sortingLayerName = "NPCInFront";
        }
        else
        {
            sprite.sortingLayerName = "NPCBehind";
        }
    }

    public void UnfreezePlayer()
    {
        playerController.IsInteracting(false);
    }

    // public void OnInteract()
    // {
    //     dialogue.gameObject.SetActive(true);
    //     dialogue.AdvanceDialog();  // Starts the first part of dialogue, since the dialogue box opens with no text initially
    // }

    public void interact()
    {
        playerController.IsInteracting(true);
        dialogue.gameObject.SetActive(true);
        dialogue.AdvanceDialog();  // Starts the first part of dialogue, since the dialogue box opens with no text initially
    }
}
