using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;

    [Space(10)]
    [Header("Checkpoints")]
    [SerializeField]
    private Vector2[] checkpoints;

    private int currentCP = 0;

    private bool interacting = false;
    private bool reachedCheckpoint = false;

    // Start is called before the first frame update
    void Start()
    {
        target.position = checkpoints[currentCP];
        currentCP++;
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector3.Distance(this.transform.position, target.position) < 0.1f) && !reachedCheckpoint)
        {
            reachedCheckpoint = true;
        }
    }

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

    private void NextCheckpoint()
    {
        if(currentCP < checkpoints.Length)
        {
            target.position = checkpoints[currentCP];
            currentCP++;
        }
    }
}
