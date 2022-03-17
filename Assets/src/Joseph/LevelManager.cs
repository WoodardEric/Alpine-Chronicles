using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   public static LevelManager Instance {get; private set;}

   public int goodScene;
   public bool test = false;

   private void Awake()
   {
      // Ensure that only one instance of the LevelManager can exist
      if (Instance != null && Instance != this)
      {
         Destroy(this.gameObject);
      }
      else
      {
         // Create LevelManager and keep it between scenes
         Instance = this;
         DontDestroyOnLoad(this);
      }
   }

   // Start is called before the first frame update
   void Start(){}
   // Update is called once per frame
   void Update(){}

   public void changeScene(int toScene, int fromScene)
   {
      PlayerClass player = PlayerClass.Instance;
      Vector2 loadPos = new Vector2(0,0);
      goodScene = 1;

      if((toScene < 1) || (toScene > 3))
      {
         Debug.Log(toScene + " Is Not A Valid toScene Number");
         goodScene = 0;
      }
      if((fromScene < 1) || (fromScene > 3))
      {
         Debug.Log(fromScene + " Is Not A Valid fromScene Number");
         goodScene = 0;
      }

      if((goodScene == 0) || (test==true))
      {
         return;
      }

      SceneManager.LoadScene(toScene);

      if(toScene == 1)
      {
         loadPos.x = -9f;
         loadPos.y = -3.9f;
         player.setPlayerPos(loadPos);
      }
      else if(toScene == 2)
      {
         if(fromScene == 1)
		 {
            loadPos.x = -9f;
            loadPos.y = 3.75f;
            player.setPlayerPos(loadPos);
		 }
		 else if(fromScene == 3)
		 {
			 loadPos.x = 7.5f;
			 loadPos.y = -106f;
			 player.setPlayerPos(loadPos);
		 }
      }
	  else if(toScene == 3)
	  {
         if(fromScene == 2)
		 {
            loadPos.x = -6f;
			loadPos.y = 16f;
			player.setPlayerPos(loadPos);
		 }
	  }
   }
}