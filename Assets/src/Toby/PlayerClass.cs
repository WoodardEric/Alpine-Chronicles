/*
 * Filename:  PlayerClass.cs
 * Developer: Toby Mclenon
 * Purpose:   This file contains a class definition for the player
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Summary: This Class acts as a definition for the player stats and behaviour
 *
 * Member Variables: 
 * Instance - The existing instance of the player class
 * moveSpeed - A float defining how quickly the player moves in the world
 * health - An integer defining how much health the player currently has
 * playerAtk - An integer holding the player's current attack power
 * totalStr - An integer holding the players current strength with the current weapon strength
 * modeBC - A bool variable that defines whether the game is in BC mode or not
 * rgdb - The player's rigidbody component
 * newPos - A Vector2 variable that holds the amount of change in player movement
 * interacting - A bool variable defining if player is currently interacting with an NPC or object
 * frozen - A bool variable tied to the interacting variable to freeze player during interaction
 * gameOver - A bool variable defining whether the player has lost the game
 * inventory - A variable of type PlayerInventory, which defines the player's inventory structure
 * compSet - A bool variable for testing. Defines whether necessary player components are attached
 * updateNum - An integer that is used as a binary semaphore to prevent multiple uses of a function
 * animator - The animator component that handles the player's animation states
 * isMoving - A bool variable defining whether player is currently moving (used for animation)
 * horizontalMov - A float that holds whether the player was last moving right or left (animation)
 * verticalMov - A float that holds whether the player was last moving up or down (for animation)
 * secondsSinceDodge - A float that holds how many seconds have passed since the player last dodged
 * attackArea - A Transform that defines a center point for the player's attack
 * attackRange - A Vector2 that defines the area of a box that represents the players attack area
 * enemyLayers - A LayerMask that defines which layer to look for enemies on
 * constAttackAngle - a constant float defining the player's attack angle to be 0
 */
public class PlayerClass : MonoBehaviour
{
    // Player singleton instance
    public static PlayerClass Instance { get; private set; }

    // Player basic stat variables
    [SerializeField] float moveSpeed;
    protected int health;
    protected const int playerAtk = 1;
    protected int tempStr;
    protected int totalStr;
    bool modeBC;

    // Player position and rigidbody
    Rigidbody2D rgdb;
    Vector2 newPos;

    // Player interaction variables
    bool interacting;
    bool frozen;
    bool gameOver;

    // Player inventory
    public PlayerInventory inventory;
    public ItemClass equippedWeapon;
    public ItemClass equippedUtil;

    // Safety variables
    bool compSet;
    protected int updateNum;

    // Animation and secondary movement variables
    public Animator animator;
    bool isMoving;
    float horizontalMov;
    float verticalMov;
    float secondsSinceDodge;

    // Player attack variables
    public Transform attackArea;
    public Vector2 attackRange;
    public LayerMask enemyLayers;
    const float constAttackAngle = 0;


    /*
     * Summary: Ensures that only one instance of the player is created
     */
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


    /*
     * Summary: Initializes all the player's variables
     */
    void Start()
    {
        // Initialize player
        this.frozen = false;
        this.interacting = false;
        SetComponents();
        ResetPlayer();
        animator.SetFloat("animSpeed", moveSpeed / 5);
    }


    /*
     * Summary: Retrieves the player's components
     */
    public void SetComponents()
    {
        if (!compSet)
        {
            this.rgdb = this.GetComponent<Rigidbody2D>();
            this.inventory = new PlayerInventory();
            this.attackRange = new Vector2(0.75f, 1.5f);
            compSet = true;
            equippedWeapon = null;
            equippedUtil = null;
            tempStr = 0;
        }
    }


    /*
     * Summary: Handles player's animation, and combat
     */
    void Update()
    {
        if (this.rgdb.IsSleeping())
        {
            this.rgdb.WakeUp();
        }
        // Check if player is currently interacting, in which case the player shouldn't
        // be able to perform any action aside from the interaction
        if (!IsInteracting())
        {
            // If user presses left mouse, attack
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (equippedUtil != null)
                {
                    this.UseItem();
                }
            }

            // If user is moving on both the x and y axis, prioritize the y axis for movement and animations
            if ((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetAxisRaw("Vertical") != 0))
            {
                // Set animation movement to vertical
                verticalMov = Input.GetAxisRaw("Vertical");
                horizontalMov = 0;
                isMoving = true;

                // If the player dodges and they haven't done so in a second or more,
                // then dodge in the direction of movement and reset dodge timer
                if (Input.GetKeyDown(KeyCode.Space) && secondsSinceDodge >= 1)
                {
                    StartCoroutine(Dodge(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
                    secondsSinceDodge = 0f;
                }

                // Adjust the position and shape of the player's attack depending on which direction they are facing
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    this.attackArea.position = new Vector2(this.transform.position.x, this.transform.position.y + (1.25f * Input.GetAxisRaw("Vertical")));
                    this.attackRange = new Vector2(1.5f, 0.75f);
                }
                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    this.attackArea.position = new Vector2(this.transform.position.x, this.transform.position.y + (0.25f * Input.GetAxisRaw("Vertical")));
                    this.attackRange = new Vector2(1.5f, 0.75f);
                }
            }
            // If the user is only move in either the x OR y direction, then adjust animations and movement as needed
            else if ((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0))
            {
                // Set player animation based on input and movement direction
                horizontalMov = Input.GetAxisRaw("Horizontal");
                verticalMov = Input.GetAxisRaw("Vertical");
                isMoving = true;

                // If the player dodges and they haven't done so in a second or more,
                // then dodge in the direction of movement and reset dodge timer
                if (Input.GetKeyDown(KeyCode.Space) && secondsSinceDodge >= 1)
                {
                    StartCoroutine(Dodge(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
                    secondsSinceDodge = 0f;
                }

                // Adjust the position and shape of the player's attack depending on which direction they are facing
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    this.attackArea.position = new Vector2(this.transform.position.x + (0.5f * Input.GetAxisRaw("Horizontal")), this.transform.position.y + 0.5f);
                    this.attackRange = new Vector2(0.75f, 1.5f);
                }
                else if (Input.GetAxisRaw("Vertical") > 0)
                {
                    this.attackArea.position = new Vector2(this.transform.position.x, this.transform.position.y + (1.25f * Input.GetAxisRaw("Vertical")));
                    this.attackRange = new Vector2(1.5f, 0.75f);
                }
                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    this.attackArea.position = new Vector2(this.transform.position.x, this.transform.position.y + (0.25f * Input.GetAxisRaw("Vertical")));
                    this.attackRange = new Vector2(1.5f, 0.75f);
                }
            }
            // If player isn't currently moving, then set bool to false to allow idle animation
            else
            {
                isMoving = false;
            }

            // Notify the animator which animation to play
            animator.SetFloat("Horizontal", horizontalMov);
            animator.SetFloat("Vertical", verticalMov);
            animator.SetBool("isMoving", isMoving);
        }
        else
        {
            // Notify the animator which animation to play
            animator.SetFloat("Horizontal", horizontalMov);
            animator.SetFloat("Vertical", verticalMov);
            animator.SetBool("isMoving", false);
        }

        // Increment time since last dodge
        this.secondsSinceDodge += (1 * Time.deltaTime);
    }


    /*
     * Summary: Adds an instant impulse to the player, causing them to dodge
     *
     * Parameters:
     * xVal - A float representing the x direction to dodge
     * yVal - A float representing the y direction to dodge
     */
    IEnumerator Dodge(float xVal, float yVal)
    {
        // Add a quick impulse force to cause player to dodge
        this.rgdb.AddForce(new Vector2(xVal * 10f, yVal * 10f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);

        // Negate the force to stop the player from moving in the force direction without input
        this.rgdb.AddForce(new Vector2(xVal * -10f, yVal * -10f), ForceMode2D.Impulse);
    }


    /*
     * Summary: Ensures that other team members are not able to bring variables outside the
     *          boundaries in the editor
     */
    void OnValidate()
    {
        if (this.moveSpeed > 15)
        {
            this.moveSpeed = 15;
        }
        else if (moveSpeed < 5)
        {
            this.moveSpeed = 5;
        }

        if (this.health > 100)
        {
            this.health = 100;
        }
        else if (this.health < 0)
        {
            this.health = 0;
        }
    }


    /*
     * Summary: Handles Player movement
     */
    private void FixedUpdate()
    {
        // Check if player is currently interacting
        if (this.IsFrozen())
        {
            // Set bitmasks to freeze the players position and rotation
            this.rgdb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        // If the player is frozen but not interacting with anything
        else if (!IsFrozen() && ((rgdb.constraints & RigidbodyConstraints2D.FreezePosition) != RigidbodyConstraints2D.None))
        {
            // Get the complement of the bitmasks to unfreeze player
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


    /*
     * Summary: Makes the player attack and calls the damage function for all enemies hit
     */
    void Attack()
    {
        if (equippedWeapon == null)
        {
            totalStr = playerAtk + tempStr;
        }
        else
        {
            totalStr = playerAtk + equippedWeapon.strength + tempStr;
        }
        SoundManager.Instance.Play(SoundManager.SoundEffect.Attack);
        // Get an array of all enemies in the player's attack range during attack
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackArea.position, attackRange, constAttackAngle, enemyLayers);

        // For each of the enemies, call their damage function
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemy " + enemy.name + " Hit");
            IHitEnemies enemyHit = enemy.gameObject.GetComponent<IHitEnemies>();
            enemyHit.DamageEnemy(totalStr);  // TODO: Set a variable for attack and reference as the parameter for DamageEnemy()
            SoundManager.Instance.Play(SoundManager.SoundEffect.Damage);
        }
    }

    void UseItem()
    {
        Debug.Log(this.equippedUtil.itemName);
        if (this.equippedUtil.health != -1)
        {
            this.UpdateHealth(equippedUtil.health, true);
        }
        if (this.equippedUtil.tempStrength != (-1, -1))
        {
            int length;
            (tempStr, length) = this.equippedUtil.tempStrength;
            StartCoroutine(tempStrength(length));
        }
        if (this.equippedUtil.tempSpeed != (-1, -1))
        {
            int length;
            float prevSpeed = moveSpeed;
            (moveSpeed, length) = this.equippedUtil.tempSpeed;
            StartCoroutine(tempSpeed(length, prevSpeed));
        }
        this.equippedUtil = null;
    }

    IEnumerator tempStrength(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        tempStr = 0;;
    }

    IEnumerator tempSpeed(int waitTime, float prevMoveSpeed)
    {
        yield return new WaitForSeconds(waitTime);
        moveSpeed = prevMoveSpeed;
    }


    /*
     * Summary: Shows the player's attack area in the editor
     */
    void OnDrawGizmosSelected()
    {
        if (attackArea == null)
        {
            return;
        }
        Gizmos.DrawWireCube(attackArea.position, attackRange);
    }


    /*
     * Summary: Handles item pickups and resets interactions
     *
     * Parameters:
     * other - The Collider2D of the object that player triggered
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("COLLIDING WITH " + other.gameObject.name);
        // Check if user is interacting with something interactable or an item
        if (other.gameObject.tag == "interactable")
        {
            this.interacting = false;
            return;
        }
        else if (other.gameObject.name == "Slime")
        {
            this.UpdateHealth(-5, false);
            return;
        }
        else if (other.gameObject.tag != "item")
        {
            return;
        }

        if (++this.updateNum > 1)
        {
            this.updateNum = 0;
            return;
        }
       

        // Set up an ItemFactory and get the type of ItemFactory needed
        ItemFactory factory = null;
        factory = getFactory(other.gameObject.name);

        // If the ItemFactory exists
        if (factory != null)
        {
            // Pick up the item that the factory produces and destroy the object in the world
            ItemClass item = factory.GetItemClass();
            
            if (this.inventory.AddItem(item))
            {
                Destroy(other.gameObject);
            }
        }
        Debug.Log("CURRENT INV SIZE: " + this.inventory.count);
        
    }


    /*
     * Summary: Returns a factory depending on which one is needed
     *
     * Parameters:
     * val - The name of the factory to be called
     *
     * Returns:
     * ItemFactory - The factory that will produce the item needed
     */
    public ItemFactory getFactory(string val)
    {
        if (val == "Katana")
        {
            return new KatanaFactory();
        }
        else if (val == "WeaponTwo")
        {
            return new WeaponTwoFactory();
        }
        else if (val == "WeaponThree")
        {
            return new WeaponThreeFactory();
        }
        else if (val == "WeaponFour")
        {
            return new WeaponFourFactory();
        }
        else if (val == "WeaponFive")
        {
            return new WeaponFiveFactory();
        }
        else if (val == "WeaponSix")
        {
            return new WeaponSixFactory();
        }
        else if (val == "WeaponSeven")
        {
            return new WeaponSevenFactory();
        }
        else if (val == "WeaponEight")
        {
            return new WeaponEightFactory();
        }
        else if (val == "WeaponNine")
        {
            return new WeaponNineFactory();
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
        else if (val == "RoomKeyOne")
        {
            return new RoomKeyOneFactory();
        }
        else if (val == "RoomKeyTwo")
        {
            return new RoomKeyTwoFactory();
        }
        else if (val == "Rupee")
        {
            return new ZeldaRFactory();
        }
        return null;
    }


    /*
     * Summary: Handles interactables such as NPC's and world objects such as doors
     *
     * Parameters:
     * other - The Collider2D of the object that the player triggered
     */
    private void OnTriggerStay2D(Collider2D other)
    {
        // If the object is not interactable, return
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


    /*
     * Summary: Resets interactions
     *
     * Parameters:
     * other - The Collider2D of the object that players collider is leaving
     */
    private void OnTriggerExit2D(Collider2D other)
    {
        // Reset the player interaction
        this.interacting = false;
        //this.updateNum = 0;
    }


    /*
     * Summary: Checks whether the player is currently interacting
     *
     * Returns:
     * bool - Return true if the player is currently interacting, and false if not
     */
    public bool IsInteracting()
    {
        // Show whether use is interacting with something
        return this.interacting;
    }


    /*
     * Summary: Sets whether the player is currently interacting
     *
     * Parameters:
     * isInteracting - True if player has started interacting, false if player is ending interaction
     */
    public void IsInteracting(bool isInteracting)
    {
        // Freeze the player and update interacting variables
        this.interacting = isInteracting;
        this.frozen = isInteracting;
    }

    public void IsFrozen(bool isFrozen)
    {
        this.frozen = isFrozen;
    }

    public bool IsFrozen()
    {
        return this.frozen;
    }


    /*
     * Summary: Updates the player's health by healing or damaging depening on value of parameter
     *
     * Parameters:
     * change - The amount of health to be added (positive) or taken (negative) from the player
     */
    public void UpdateHealth(int change, bool isItem)
    {
        // Increment semaphore
        if (++this.updateNum > 1)
        {
            this.updateNum = 0;
            if (!isItem)
            {
                return;
            }
        }
        // Check if BC mode is active
        if (modeBC)
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


    /*
     * Summary: Gets the player's current health
     *
     * Returns:
     * int - Return player's current health
     */
    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int value)
    {
        if (value > 100)
        {
            value = 100;
        }

        health = value;
    }


    /*
     * Summary: Gets the current score
     *
     * Returns:
     * int - Returns the current score
     */
    public int GetScore()
    {
        return CoinPickup.GetScore();
    }


    public void SetScore(int newScore)
    {
        CoinPickup.SetScore(newScore);
    }


    /*
     * Summary: Changes player's current speed
     *
     * Parameters:
     * newSpd - The value to set player speed to
     */
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
        // Adjust animation speed based on players movement speed
        animator.SetFloat("animSpeed", moveSpeed / 5);
    }


    /*
     * Summary: Gets the player's current speed
     *
     * Returns:
     * float - Return player's current movement speed
     */
    public float GetSpd()
    {
        return moveSpeed;
    }


    /*
     * Summary: Gets the player's current strength
     *
     * Returns:
     * float - Return player's current strength
     */
    public int GetStr()
    {
        return totalStr;
    }


    /*
     * Summary: Determines game over state if player dies
     */
    private void GameOverAct()
    {
        Application.Quit();
    }


    /*
     * Summary: Enables Dr. BC mode if the password is correct
     *
     * Parameters:
     * password - The password entered and received from the password menu class
     *
     * Returns:
     * bool - Return true if the password was correct and false if not
     */
    public bool StartBCMode(string password)
    {
        // Check whether password is correct
        if (password.Equals("GoBig", StringComparison.Ordinal))
        {
            // If correct passowrd, activate BC mode
            this.modeBC = true;
        }

        return this.modeBC;
    }


    /*
     * Summary: Gets the player's current position as a Vector2
     *
     * Returns:
     * Vector2 - The player's current x and y positions
     */
    public Vector2 GetPos()
    {
        return new Vector2(this.transform.position.x, this.transform.position.y);
    }


    /*
     * Summary: Sets the player's absolute position
     *
     * Parameters:
     * pos - The Vector2 containing the x and y coordinates to move the player to
     */
    public void SetPlayerPos(Vector2 pos)
    {
        // Set the player's position
        this.transform.position = new Vector3(pos.x, pos.y, 0);
    }


    /*
     * Summary: Resets the player to a default state
     */
    public void ResetPlayer()
    {
        this.health = 100;
        this.totalStr = playerAtk;
        this.updateNum = 0;
        this.modeBC = false;
        this.gameOver = false;
        this.isMoving = false;
        this.horizontalMov = 0.0f;
        this.verticalMov = -1.0f;
        this.secondsSinceDodge = 0;
        inventory.ResetInventory();
        SetScore(0);
    }
}