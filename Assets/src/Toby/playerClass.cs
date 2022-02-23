using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerClass : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rgdb;
    Vector2 newPos;
    bool interacted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rgdb =  this.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        newPos = new Vector2(this.transform.position.x, this.transform.position.y);
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            newPos.x += (moveSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
        }

        if(Input.GetAxisRaw("Vertical") != 0)
        {
            newPos.y += (moveSpeed * Input.GetAxisRaw("Vertical") * Time.deltaTime);
        }
        
        rgdb.MovePosition(newPos);
        this.transform.rotation = Quaternion.identity;
    }

    // private void FixedUpdate()
    // {
    //     if(Input.GetAxisRaw("Horizontal") != 0)
    //     {
    //         this.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0.0f, 0.0f));
    //     }

    //     if(Input.GetAxisRaw("Vertical") != 0)
    //     {
    //         this.transform.Translate(new Vector3(0.0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0.0f));
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "item")
        {
            return;
        }

        pickupItem(other.gameObject);
        Destroy(other.gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name != "Computer")
        {
            return;
        }
        
        // if (interacted == 1)
        // {
        //     return;
        // }

        if (Input.GetKey(KeyCode.E) && !interacted)
        {
            Debug.Log("Player has interacted with the computer");
            interacted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interacted = false;    
    }

    private void pickupItem(GameObject item)
    {
        Debug.Log("Picked up a " + item.name + " item.");
    }
}
