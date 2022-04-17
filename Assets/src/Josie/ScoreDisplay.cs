/*
 * Filename:  ScoreDisplay.cs
 * Developer: Josie Wicklund
 * Purpose:   This file contains a class definition for score display
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Summary: This Class deals with the ScoreDisplay prefab 
 *
 * Member Variables: 
 * Instance: The existing instance of scoreDisplay 
 * ScoreText: variable that accesses text on the score
 * Player: creates variable of type PlayerClass that is used to get score of player
 *
 */
public class ScoreDisplay : MonoBehaviour
{
    public static ScoreDisplay Instance { get; private set; }
    
    public Text ScoreText;
    public PlayerClass Player = null;


    /*
     * Summary: Ensures that only one instance of the scoredisplay is created
     */
    private void Awake()
    {
        // Ensure that only one instance of the displayscore can exist
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Create displayscore and keep between scenes
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }


    /*
     * Summary: creates instance of the player
     */
    void Start()
    {
        Player = PlayerClass.Instance;
    }


    /*
     * Summary: Gets the score and updates the text 
     */
    void Update()
    {
        int Score = Player.GetScore();
        ScoreText.text = Score.ToString();
    }
}
