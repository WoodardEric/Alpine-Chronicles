using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerClass : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rgdb;
    Vector2 newPos;
    bool interacting = false;
    bool frozen = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rgdb =  this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(!frozen)
        {
            newPos = new Vector2(this.transform.position.x, this.transform.position.y);
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                newPos.x += (moveSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                newPos.y += (moveSpeed * Input.GetAxisRaw("Vertical") * Time.deltaTime);
            }

            rgdb.MovePosition(newPos);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "item")
        {
            return;
        }

        pickupItem(other.gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag != "interactable")
        {
            return;
        }

        if (Input.GetKey(KeyCode.E) && !interacting)
        {
            IInteractable interactedObj = other.gameObject.GetComponent<IInteractable>();
            interactedObj.interact();
            interacting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interacting = false;    
    }

    private void pickupItem(GameObject item)
    {
        Debug.Log("Player has picked up a " + item.name + " item.");
    }

    public bool isInteracting()
    {
        return interacting;
    }

    public void isInteracting(bool isInteracting)
    {
        interacting = isInteracting;
        frozen = isInteracting;
    }
}
