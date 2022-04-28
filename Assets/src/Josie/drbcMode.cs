/*
 * Filename:  drbcMode.cs
 * Developer: Josie Wicklund
 * Purpose:   This file contains drbcmode child class 
 */
 
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Summary: This Class is drBCmode sub class
 *
 * Member Variables: 
 * isValid: bool variable checking for input password correctness
 * input: private string that recieves input from text box
 */
public class drbcMode : MenuManager
{
    public bool isValid;
    private string input;
    

     /*
     * Summary: Reads string and checks input to enter into drbcmode 
     */
    public void readStringInput(string s)
    {
        input = s;
        if(input.Length < 1)
        {
            Debug.Log("Password must be at least 1 character");
            isValid = false;
        }
        else if (input.Length > 10)
        {
            Debug.Log("Password must be less than 10 characters");
            isValid = false;
        }
        else
        {
            Debug.Log(input);

            bool check = checkPassword(input);

            if (check)
            {
                SceneManager.LoadScene("Level_0");
                PlayerClass player = PlayerClass.Instance;
                player.SetPlayerPos(new Vector2(-5.18f, -2.87f));
                player.IsInteracting(false);
                isValid = true; 
            }
            else
            {
                Debug.Log("Incorrect Password");
                isValid = true;
            }
            
        }
    }
    

     /*
     * Summary: input validation
     * 
     * Parameters: 
     *  s: string that contains the inpute 
     */
    private bool checkPassword(string s)
    {
        PlayerClass player = PlayerClass.Instance;
        
        bool correct = player.StartBCMode(s); //GoBig 

        if(correct == true)
        {
            Debug.Log("Password is correct");
            return true;
        }

        Debug.Log("Password is wrong");
        return false;
    }

    public override void SayHello()
    {
        Debug.Log("Hello, from drbcMode");
    }
}
