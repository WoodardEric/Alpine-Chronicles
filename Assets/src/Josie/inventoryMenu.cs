using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryMenu : MonoBehaviour
{
    public static bool inventroyCalled = false;

    public GameObject inventory;
    PlayerClass player = null;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerClass.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }

    public void inventoryButton()
    {
        Debug.Log("Inventory menu");
        inventory.SetActive(true);
        Time.timeScale = 0f; 
        inventroyCalled = true;
        player.IsInteracting(true);
    }

    public void ResumeGame()
    {
        inventory.SetActive(false);
        Time.timeScale = 1f; 
        inventroyCalled = false;
        player.IsInteracting(false);
    }

}
