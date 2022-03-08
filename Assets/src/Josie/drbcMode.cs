using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class drbcMode : MonoBehaviour
{
    private string input;

    public bool readStringInput(string s)
    {
        input = s;
        if(input.Length < 1)
        {
            Debug.Log("Password must be at least 1 character");
            return false;
        }
        else if (input.Length > 10)
        {
            Debug.Log("Password must be less than 10 characters");
            return false;
        }
        else
        {
            Debug.Log(input);

            bool check = checkPassword(input);

            if (check)
            {
                SceneManager.LoadScene("Level_0");
                PlayerClass player = PlayerClass.Instance;
                player.setPlayerPos(new Vector2(-5.18f, -2.87f));
                return true; 
            }
            else
            {
                Debug.Log("Incorrect Password");
                return true;
            }
            
        }
    }

    private bool checkPassword(string s)
    {
        PlayerClass player = PlayerClass.Instance;
        
        bool correct = player.startBCMode(s); //GoBig 

        if(correct == true)
        {
            Debug.Log("Password is correct");
            return true;
        }

        Debug.Log("Password is wrong");
        return false;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
