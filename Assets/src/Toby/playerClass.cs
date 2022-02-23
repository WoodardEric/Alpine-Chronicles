using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerClass : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody2D rgdb;
    Vector2 newPos;
    
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

    void OnTriggerEnter2D (Collider2D col)
    {
       if(col.gameObject.name == "Computer"){
           Debug.Log("Player has interacted with the computer.");
       }

   }
}
