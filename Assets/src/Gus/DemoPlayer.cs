/*
 * Filename: DemoPlayer.cs
 * Developer: Gus
 * Purpose: AI Player for the "demo mode" for the game to play itself. 
 * Uses a Unity asset store asset called SAP2D. Still unfinished WIP.
 * Defnines Start(), Update(), OnTriggerStay2D(), and NextCheckpoint().
 */

using UnityEngine;

/// <summary>
/// Uses an array of given checkpoints to move the “AI player” through the scene.
/// </summary>
public class DemoPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;

    [Space(10)]
    [Header("Checkpoints")]
    [SerializeField]
    private Vector2[] checkpoints; // Defines the Vector2 position of each checkpoint.

    private int currentCP = 0; // The index of the current given checkpoint.

    private bool reachedCheckpoint = false; // If the “AI player” has reached the checkpoint.

    /// <summary>
    /// This function sets the default values at runtime.
    /// </summary>
    void Start()
    {
        target.position = checkpoints[currentCP];
        currentCP++;
    }

    /// <summary>
    /// Checks to see if the user has reached the given checkpoint in order
    /// to progress to the next checkpoint.The distance check is present to 
    /// determine if the AI player is close enough to the given checkpoint.
    /// </summary>
    void Update()
    {
        if((Vector3.Distance(this.transform.position, target.position) < 0.1f) && !reachedCheckpoint)
        {
            reachedCheckpoint = true;
        }
    }

    /// <summary>
    /// Function to artificially interact with and interactable object. For example: doors.
    /// </summary>
    /// <param name="other">
    /// Is the new collider interacting with this object?
    /// </param>
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag != "interactable")
        {
            return;
        }

        // Interact with the object if the user it touchinig it an presses E
        if (reachedCheckpoint)
        {
            // Create a temp object to utilize the Interactable interface, then interact with it
            IInteractable interactedObj = other.gameObject.GetComponent<IInteractable>();
            interactedObj.interact();
            NextCheckpoint();
            reachedCheckpoint = false;
        }
    }

    /// <summary>
    /// Increments the array buy one to progress to the next given checkpoint.
    /// </summary>
    private void NextCheckpoint()
    {
        if(currentCP < checkpoints.Length)
        {
            target.position = checkpoints[currentCP];
            currentCP++;
        }
    }
}