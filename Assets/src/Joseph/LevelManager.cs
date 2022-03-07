using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
   private static LevelManager _instance ;

   public static LevelManager LMInstance
   {
      get
      {
         if( _instance == null)
         {
            Debug.LogError("LevelManager is NULL");
         }
         return _instance;
      }
   }

   PlayerClass player = PlayerClass.Instance;

   private void Awake()
   {
      _instance = this;
      DontDestroyOnLoad(this);
   }

   // Start is called before the first frame update
   void Start(){}
   // Update is called once per frame
   void Update(){}

   public void changeScene(int toScene, int fromScene)
   {
      Vector2 loadPos = new Vector2(0,0);
      SceneManager.LoadScene(toScene);

      if(toScene == 1)
      {
         loadPos.x = -9f;
         loadPos.y = -3.9f;
         player.setPlayerPos(loadPos);
      }
      else if(toScene == 2)
      {
         loadPos.x = -9f;
         loadPos.y = 3.75f;
         player.setPlayerPos(loadPos);
      }
   }
}