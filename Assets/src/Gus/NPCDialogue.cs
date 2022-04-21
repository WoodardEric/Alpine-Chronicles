/*
 * Filename: NPCDialogue.cs
 * Developer: Gus
 * Purpose: Provide dialogue for the player to read when interacting with an NPC.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Define Awake(), Update(), AdvanceDialog(), AdvanceDialogSkip(), ShowText()
/// 
/// [Serielizefeild] is used extensively here in order to facilitate speedy edits
/// through the Unity Editor instead of having to constantly go back into the 
/// script to edit options for dialogue text that the NPCs have.
/// </summary>
public class NPCDialogue : MonoBehaviour
{
    [Header("Public References")]
    [SerializeField]
    private NPC npcController;
    [Space]
    [SerializeField]
    private Text textContainer; // What dialogue text is displayed to the player.
    [Space]
    [SerializeField]
    private bool cycleOnClick; // Toggle to progress the text forward if the programmer would like to set dialogue progression to the user's mouse click.
    [Space]
    [SerializeField]
    private bool cycleOnButton; // Toggle to progress the text forward if the programmer would like to set dialogue progression to a "button" in untiy.
    private Button buttonToAdvanceDiaglog;
    [Header("Key Controls")]
    [Space]
    [SerializeField]
    private bool cycleOnKey; // Toggle to progress the text forward if the programmer would like to set dialogue progression to a given key on the keyboard.
    [SerializeField]
    private KeyCode keyPressToAdvance; // Given key on the keyboard is defined here.
    [Space]
    [SerializeField]
    private bool deactivateThisObjectAfterDialog = false; // Toggle to make the NPC not interactable once the dialogue has finished.
    [Space]
    [SerializeField]
    private bool activateTargetObjectAfterDialog = false; // Toggle to activate a certain object in the scene that the programmer may see fit once dialogue has progressed.
    [SerializeField]
    private GameObject targetGameObject; // Defines the target object in the scene related to the above variable.
    [Space]
    [SerializeField]
    private bool resetAfterDialog = false; // Resets the NPC once the dialogue has finished.
    [Space]
    [SerializeField]
    private float textSpeed = 0.05f;  // The speed at which you'll see the game type the text.
    [Space]
    [SerializeField]
    private List<string> dialogContentRollout; //Defines what dialogue text will be displayed to the player.
    [Space]
    int current = -1;

    private string full_text; 
    private string current_text; 
    private bool text_done = true; 
    private int length = 0;

    /// <summary>
    /// Checks to make sure all variables are assigned properly to the dialogue. 
    /// Also adds a listener to the button if that is the desired method that the
    /// programmer wants to use.
    /// </summary>
    void Awake()
    {
        if (textContainer == null)
        {
            Debug.LogError("dialogScript must have a Text Container!");
            gameObject.SetActive(false);
            return;
        }

        textContainer.text = "";

        if (cycleOnButton && buttonToAdvanceDiaglog == null)
        {
            Debug.LogError("dialogScript must have a button for 'Cycle On Button'");
        }
        else if (cycleOnButton)
        {
            buttonToAdvanceDiaglog.onClick.AddListener(AdvanceDialog);
        }

        if (activateTargetObjectAfterDialog && targetGameObject == null)
        {
            Debug.LogError("dialogScript must have a target for 'activateTargetObjectAfterDialog'");
        }

        if (dialogContentRollout.Count == 0)
        {
            Debug.LogWarning("dialogScript on " + gameObject.name + "has an empty rollout");
        };
    }

    /// <summary>
    /// Syncs the text output to update so that text is consistent regardless of frame rate. 
    /// This function also monitors the given key or mouse button to progress the dialogue faster
    /// or at a normal rate.
    /// This function also calls the appropriate child functions AdvanceDialogSkip(), AdvanceDialog().
    /// </summary>
    void Update()
    {
        if (cycleOnClick && Input.GetMouseButtonDown(0) && text_done == false)
        {
            AdvanceDialogSkip();
        }
        if (cycleOnClick && Input.GetMouseButtonDown(0) && text_done)
        {
            AdvanceDialog();
        }
        if (cycleOnKey && Input.GetKeyDown(keyPressToAdvance) && text_done == false)
        {
            AdvanceDialogSkip();
        }
        if (cycleOnKey && Input.GetKeyDown(keyPressToAdvance) && text_done)
        {
            AdvanceDialog();
        }
    }

    /// <summary>
    /// Displays the text of the dialogue for the given NPC by calling the coroutine ShowText().
    /// This function also unfreezes the player once dialogue has been finished.
    /// </summary>
    public void AdvanceDialog()
    {
        current++;

        if (current < dialogContentRollout.Count)
        {
            full_text = dialogContentRollout[current];
            StartCoroutine(ShowText());
        }
        else
        {
            textContainer.text = "";
            if (current >= dialogContentRollout.Count)
            {
                //current = dialogContentRollout.Count;
                if (activateTargetObjectAfterDialog)
                {
                    targetGameObject.SetActive(true);
                }

                if (deactivateThisObjectAfterDialog)
                {
                    gameObject.SetActive(false);
                }

                if (resetAfterDialog)
                {
                    current = -1;
                }

                npcController.UnfreezePlayer(); //Unfrezes the player once dialogue has finished
            }
        }
    }

    /// <summary>
    /// This skips the typing effect and just pastes the message.
    /// It can only occur if the typing effect is currently occuring.
    /// </summary>
    void AdvanceDialogSkip() 
    {
        if (current < dialogContentRollout.Count)
        {
            length = full_text.Length + 2;
            textContainer.text = dialogContentRollout[current];
        }
        else
        {
            textContainer.text = "";
            if (current >= dialogContentRollout.Count)
            {
                //current = dialogContentRollout.Count;
                if (activateTargetObjectAfterDialog)
                {
                    targetGameObject.SetActive(true);
                }

                if (deactivateThisObjectAfterDialog)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    /// <summary>
    /// This is the coroutine for displaying the text one char at a time.
    /// </summary>
    IEnumerator ShowText()
    {
        text_done = false;
        length = 0;
        while (length < full_text.Length + 1)
        {
            current_text = full_text.Substring(0, length);
            textContainer.text = current_text;
            yield return new WaitForSeconds(textSpeed);
            length++;
        }
        text_done = true;
    }
}
