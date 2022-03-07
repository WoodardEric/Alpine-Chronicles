using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StressPlayer : MonoBehaviour
{
    public static StressPlayer Instance { get; private set; }

    public float moveSpeed;
    Rigidbody2D rgdb;
    Vector2 newPos;

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
        this.rgdb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
            // Get the players current position
            this.newPos = new Vector2(this.transform.position.x, this.transform.position.y);

            //if (Input.GetAxisRaw("Horizontal") != 0){
            this.newPos.x += (this.moveSpeed * Time.deltaTime);
            //}

            // Apply any position adjustments made to the player
            this.rgdb.MovePosition(newPos);
    }

    public void setPlayerPos(Vector2 pos)
    {
        // Set the player's position
        this.transform.position = new Vector3(pos.x, pos.y, 0);
    }
}