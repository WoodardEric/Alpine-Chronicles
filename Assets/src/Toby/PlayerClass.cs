using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerClass : MonoBehaviour
{
    public static PlayerClass Instance { get; private set; }

    [SerializeField] float moveSpeed;
    protected int health;
    bool BCMode;
    Rigidbody2D rgdb;
    Vector2 newPos;
    bool interacting;
    bool frozen;
    bool gameOver;
    InventoryClass inventory = new PlayerInventory();
    bool compSet;
    int updateNum;

    private void Awake()
    {
        // Ensure that only one instance of the player can exist
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Create player and Keep player between scenes
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize player
        this.health = 100;
        this.updateNum = 0;
        this.BCMode = false;
        this.gameOver = false;
        this.frozen = false;
        this.interacting = false;
        this.compSet = false;
        setComponents();
    }

    public void setComponents()
    {
        if (!compSet)
        {
            this.rgdb = this.GetComponent<Rigidbody2D>();
            this.inventory = this.GetComponent<PlayerInventory>();
            compSet = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnValidate()
    {
        if (moveSpeed > 15)
        {
            moveSpeed = 15;
        }
        else if (moveSpeed < 5)
        {
            moveSpeed = 5;
        }
    }

    private void FixedUpdate()
    {
        // If the player is not currently interacting with something
        if(!this.frozen)
        {
            // Get the players current position
            this.newPos = new Vector2(this.transform.position.x, this.transform.position.y);
            
            // If user is moving left or right, adjust the x position of the player
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                this.newPos.x += (this.moveSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
            }

            // If user is moving up or down, adjust the y position of the player
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                this.newPos.y += (this.moveSpeed * Input.GetAxisRaw("Vertical") * Time.deltaTime);
            }

            // Apply any position adjustments made to the player
            this.rgdb.MovePosition(newPos);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if user is interacting with something interactable or an item
        if (other.gameObject.tag == "interactable")
        {
            this.interacting = false;
            return;
        }
        else if (other.gameObject.tag != "item")
        {
            return;
        }
        
        pickupItem(other.gameObject.GetComponent<ItemClass>());
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag != "interactable")
        {
            return;
        }

        // Interact with the object if the user it touchinig it an presses E
        if (Input.GetKey(KeyCode.E) && !this.interacting)
        {
            // Create a temp object to utilize the Interactable interface, then interact with it
            IInteractable interactedObj = other.gameObject.GetComponent<IInteractable>();
            this.interacting = true;
            interactedObj.interact();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Reset the player interaction
        this.interacting = false;
        this.updateNum = 0;
    }

    private void pickupItem(ItemClass item)
    {
        addInvItem(item);
        Debug.Log("Player has picked up a " + item.name + " item.");
    }

    public bool isInteracting()
    {
        // Show whether use is interacting with something
        return this.interacting;
    }

    public void isInteracting(bool isInteracting)
    {
        // Freeze the player and update interacting variables
        this.interacting = isInteracting;
        this.frozen = isInteracting;
    }

    public void updateHealth(int change)
    {
        if (++this.updateNum > 1)
        {
            return;
        }
        // Check if BC mode is active
        if (BCMode)
        {
            // Create a temporary long variable to hold the health's value (to prevent underflow)
            long rangeExp = (long)this.health + (long)change;
            // If user's health will be over 100, set it to the max of 100
            if ((rangeExp) > 100)
            {
                this.health = 100;
            }
            // If the new health is a lower value than the variable can hold, set it to the min value
            else if (rangeExp < Int32.MinValue)
            {
                this.health = Int32.MinValue;
            }
            // If the health is within range, then adjust as normal
            else
            {
                this.health += change;
            }
            // Finish updating health
            Debug.Log("Player health is now " + this.health);
            return;
        }

        // If user's health will be over 100, set it to the max of 100
        if ((health + change) > 100)
        {
            health = 100;
        }
        // If user's health will be less than 0, set it to 0 and trigger game over
        else if ((this.health + change) <= 0)
        {
            this.health = 0;
            this.gameOverAct();
        }
        // Adjust health as normal
        else
        {
            this.health += change;
        }
        Debug.Log("Player health is now " + this.health);
    }

    public int getHealth()
    {
        return health;
    }

    public void setSpd(float newSpd)
    {
        moveSpeed = newSpd;
    }

    public float getSpd()
    {
        return moveSpeed;
    }

    private void gameOverAct()
    {

    }

    public bool startBCMode(string password)
    {
        // Check whether password is correct
        if (password.Equals("GoBig", StringComparison.Ordinal))
        {
            // If correct passowrd, activate BC mode
            this.BCMode = true;
        }

        return this.BCMode;
    }

    public void setPlayerPos(Vector2 pos)
    {
        // Set the player's position
        this.transform.position = new Vector3(pos.x, pos.y, 0);
    }

    public bool addInvItem(ItemClass addedItem)
    {
        return this.inventory.addItem(addedItem);
    }

    public bool removeInvItem(int invIndex)
    {
        return this.inventory.removeItem(invIndex);
    }

    public int getNumInvItems()
    {
        return this.inventory.getNumItems();
    }

    public int getMaxItems()
    {
        return this.inventory.getMaxItems();
    }

    public ItemClass getInvItem(int index)
    {
        return inventory.getItem(index);
    }

    public void switchInvItems(int InvitemOne, int InvitemTwo)
    {
        inventory.switchItems(InvitemOne, InvitemTwo);
    }
}