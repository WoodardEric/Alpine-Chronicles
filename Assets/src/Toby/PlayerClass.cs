using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public static PlayerClass Instance { get; private set; }
    [SerializeField] float moveSpeed;
    public int health;
    protected int playerAtk;
    bool BCMode;
    Rigidbody2D rgdb;
    Vector2 newPos;
    bool interacting;
    bool frozen;
    bool gameOver;
    PlayerInventory inventory;
    bool compSet;
    protected int updateNum;

    public Animator animator;
    bool isMoving;
    float horizontalMov;
    float verticalMov;

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
        this.playerAtk = 1;
        this.updateNum = 0;
        this.BCMode = false;
        this.gameOver = false;
        this.frozen = false;
        this.interacting = false;
        this.compSet = false;
        this.isMoving = false;
        this.horizontalMov = 0;
        this.verticalMov = 0;
        animator.SetFloat("animSpeed", moveSpeed / 5);

        SetComponents();
    }

    public void SetComponents()
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
        if (!IsInteracting())
        {
            if ((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetAxisRaw("Vertical") != 0))
            {
                verticalMov = Input.GetAxisRaw("Vertical");
                horizontalMov = 0;
                
                isMoving = true;
            }
            else if ((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0))
            {
                horizontalMov = Input.GetAxisRaw("Horizontal");
                verticalMov = Input.GetAxisRaw("Vertical");
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
            animator.SetFloat("Horizontal", horizontalMov);
            animator.SetFloat("Vertical", verticalMov);
            animator.SetBool("isMoving", isMoving);
        }
        else
        {
            animator.SetFloat("Horizontal", horizontalMov);
            animator.SetFloat("Vertical", verticalMov);
            animator.SetBool("isMoving", false);
        }
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
        if (this.IsInteracting())
        {
            this.rgdb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        else if (!IsInteracting() && ((rgdb.constraints & RigidbodyConstraints2D.FreezePosition) != RigidbodyConstraints2D.None))
        {
            this.rgdb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            this.rgdb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        }
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
        
        ItemFactory factory = null;
        factory = getFactory(other.gameObject.name);

        if (factory != null)
        {
            ItemClass item = factory.GetItemClass();
            if (PickupItem(item))
            {
                Destroy(other.gameObject);
            }
        }
    }

    public ItemFactory getFactory(string val)
    {
        if (val == "Katana")
        {
            return new KatanaFactory();
        }
        else if (val == "Weapon2")
        {
            return new Weapon2Factory();
        }
        else if (val == "Weapon3")
        {
            return new Weapon3Factory();
        }
        else if (val == "Weapon4")
        {
            return new Weapon4Factory();
        }
        else if (val == "Weapon5")
        {
            return new Weapon5Factory();
        }
        else if (val == "Weapon6")
        {
            return new Weapon6Factory();
        }
        else if (val == "Weapon7")
        {
            return new Weapon7Factory();
        }
        else if (val == "Weapon8")
        {
            return new Weapon8Factory();
        }
        else if (val == "Weapon9")
        {
            return new Weapon9Factory();
        }
        else if (val == "HealthApple")
        {
            return new HealthAppleFactory();
        }
        else if (val == "HealthCheese")
        {
            return new HealthCheeseFactory();
        }
        else if (val == "HealthPotion")
        {
            return new HealthPotionFactory();
        }
        else if (val == "SpeedPotion")
        {
            return new SpeedPotionFactory();
        }
        else if (val == "StrengthPotion")
        {
            return new StrengthPotionFactory();
        }
        else if (val == "BossKey")
        {
            return new BossKeyFactory();
        }
        else if (val == "RoomKey1")
        {
            return new RoomKey1Factory();
        }
        else if (val == "RoomKey2")
        {
            return new RoomKey2Factory();
        }
        return null;
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

    private bool PickupItem(ItemClass item)
    {
        return AddInvItem(item);
    }

    public bool IsInteracting()
    {
        // Show whether use is interacting with something
        return this.interacting;
    }

    public void IsInteracting(bool isInteracting)
    {
        // Freeze the player and update interacting variables
        this.interacting = isInteracting;
        this.frozen = isInteracting;
    }

    public void UpdateHealth(int change)
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
            this.GameOverAct();
        }
        // Adjust health as normal
        else
        {
            this.health += change;
        }
        
        Debug.Log("Player health is now " + this.health);
        
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetSpd(float newSpd)
    {
        if (newSpd > 15)
        {
            newSpd = 15;
        }
        else if (newSpd < 2.5f)
        {
            newSpd = 2.5f;
        }
        moveSpeed = newSpd;
        animator.SetFloat("animSpeed", moveSpeed / 5);
    }

    public float GetSpd()
    {
        return moveSpeed;
    }

    private void GameOverAct()
    {

    }

    public bool StartBCMode(string password)
    {
        // Check whether password is correct
        if (password.Equals("GoBig", StringComparison.Ordinal))
        {
            // If correct passowrd, activate BC mode
            this.BCMode = true;
        }

        return this.BCMode;
    }

    public Vector2 getPos()
    {
        return new Vector2(this.transform.position.x, this.transform.position.y);
    }

    public void SetPlayerPos(Vector2 pos)
    {
        // Set the player's position
        this.transform.position = new Vector3(pos.x, pos.y, 0);
    }

    public bool AddInvItem(ItemClass addedItem)
    {
        return this.inventory.AddItem(addedItem);
    }

    public bool RemoveInvItem(int invIndex)
    {
        return this.inventory.RemoveItem(invIndex);
    }

    public bool RemoveInvItem(string itemName)
    {
        return this.inventory.RemoveItem(itemName);
    }

    public int GetNumInvItems()
    {
        return this.inventory.GetNumItems();
    }

    public int GetMaxItems()
    {
        return this.inventory.GetMaxItems();
    }

    public ItemClass GetInvItem(int index)
    {
        return inventory.GetItem(index);
    }

    public ItemClass GetInvItem(string name)
    {
        return inventory.GetItem(name);
    }

    public void SwitchInvItems(int InvitemOne, int InvitemTwo)
    {
        inventory.SwitchItems(InvitemOne, InvitemTwo);
    }

    public void TestingList()
    {
        inventory.CreateTestList();
    }
}