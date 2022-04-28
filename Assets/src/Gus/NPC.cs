/*
 * Filename: NPC.cs
 * Developer: Gus
 * Purpose: Defines the Basic NPC that the player can interact with.
 */
using UnityEngine;

/// <summary>
/// Defines the Basic NPC that the player can interact with.
/// </summary>
public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField]
    private NPCDialogue dialogue = null;
    private PlayerClass playerController = null;
    SpriteRenderer sprite;

    /// <summary>
    /// Searches the heirarchy for the "Player" and reports an error if the components looking for on the player are not found.
    /// </summary>
    private void Start()
    {
        playerController = PlayerClass.Instance;
        if (playerController == null)
        {
            Debug.LogError("No player class script was found on the player");
            this.gameObject.SetActive(false);
            return;
        }

        sprite = this.GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Ensures that the sprite for the given NPC is rendered correctly.
    /// </summary>
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

    /// <summary>
    /// Unfrezes the player when not interacting with the NPC.
    /// </summary>
    public void UnfreezePlayer()
    {
        playerController.IsInteracting(false);
    }

    /// <summary>
    /// Starts the first part of dialogue, since the dialogue box opens with no text initially
    /// </summary>
    public void interact()
    {
        playerController.IsInteracting(true);
        dialogue.gameObject.SetActive(true);
        dialogue.AdvanceDialog();
    }
}