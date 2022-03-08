using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class drbcMode : MonoBehaviour
{
    private string input;

    public void readStringInput(string s)
    {
        input = s;
        if(input.Length >= 1 && input.Length <= 10)
        {
            Debug.Log(input);
            checkPassword(input);
        }
        else
        {
            Debug.Log("password must be less than 10 characters");
        }
    }

    private void checkPassword(string s)
    {
        PlayerClass T;
        
        bool check = T.startBCMode(s); //GoBig 

        if(check = true)
        {
            Debug.Log("password is correct");
        }

        Debug.Log("password is wrong");
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
