using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    [Header("Public References")]
    [SerializeField]
    private NPC npcController;
    [Space]
    [SerializeField]
    private Text textContainer;
    [Space]
    [SerializeField]
    private bool cycleOnClick;
    [Space]
    [SerializeField]
    private bool cycleOnButton;
    private Button buttonToAdvanceDiaglog;
    [Header("Key Controls")]
    [Space]
    [SerializeField]
    private bool cycleOnKey;
    [SerializeField]
    private KeyCode keyPressToAdvance;
    [Space]
    [SerializeField]
    private bool deactivateThisObjectAfterDialog = false;
    [Space]
    [SerializeField]
    private bool activateTargetObjectAfterDialog = false;
    [SerializeField]
    private GameObject targetGameObject;
    [Space]
    [SerializeField]
    private bool resetAfterDialog = false;
    [Space]
    [SerializeField]
    private float textSpeed = 0.05f;  //The speed at which you'll see the game type the text
    [Space]
    [SerializeField]
    private List<string> dialogContentRollout;
    [Space]
    int current = -1;

    private string full_text;
    private string current_text;
    private bool text_done = true;
    private int length = 0;  //Here because it needs to be stated throughout the script

    // Checking to make sure things are assigned properly
    // Also adds a listner to the button if that is selected
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

                npcController.UnfreezePlayer();
            }
        }
    }

    void AdvanceDialogSkip() //This skips the typing effect and just pastes the message, it can only occur if the typing effect is currently occuring
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

    // The coroutine for displaying the text one char at a time
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
