using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make system serializable so we can put in file stream. 
[System.Serializable]
public class PlayerData : MonoBehaviour
{  
    public playerClass myStats;

    public void update ()
    {
        //save current position as new position.
        Vector3 pos = transform.position;
        pos.x = myStats.newPos.x;
        pos.y = myStats.newPos.y;
        transform.position = pos; 


    }
    
}
