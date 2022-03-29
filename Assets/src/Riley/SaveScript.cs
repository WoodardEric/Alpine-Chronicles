using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveScript : MonoBehaviour
{
    //public int healthy;
    public PlayerClass player = null;
    public Slider slider;
    //public HealthBar Slider; 
    // Start is called before the first frame update
    void Start()
    {
       
        player = PlayerClass.Instance;
        //healthy = myObject.GetHealth();
        //PlayerPrefs.GetInt("health");
    }

    // Update is called once per frame
    void Update()
    {
        //int i = player.GetHealth();
        //SetHealth(i);
        //int sethealth = player.GetHealth();
        //savelevel(sethealth);

    }

    public void Create()
    { 
    
   
    
    }

    public void savelevel()
    {   //Get active scene
        //PlayerClass myObject = GameObject.FindObjectOfType<PlayerClass>();
        PlayerClass myObject = GameObject.FindObjectOfType<PlayerClass>();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        //public int healthy = player.health;
        int healthy = player.GetHealth();
        PlayerPrefs.SetInt("health",healthy);
       
        Debug.Log("saving..."+healthy);
    }


    public void LoadNumber()
    {
        PlayerClass myObject = GameObject.FindObjectOfType<PlayerClass>();
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
        PlayerClass player = PlayerClass.Instance;
        player.IsInteracting(false);
        player.SetPlayerPos(new Vector2(-5.18f, -2.87f));

        int healthy = PlayerPrefs.GetInt("health");
        //player.UpdateHealth(healthy);
        player.health = healthy; 
        //healthy =  PlayerPrefs.GetInt("health");
        Debug.Log("Loading..." + healthy);
      
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //move slider on health bar 
    public void SetHealth(int health)
    {
        slider.value = health;
    }




}
