using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDoor : Door
{

   public int toScene;
   public int fromScene;
   //LevelManager LM = LevelManager.Instance;

   override public void interact()
   {
      LevelManager.Instance.changeScene(toScene,fromScene);
      //SceneManager.LoadScene(toScene);
      Debug.Log("Change Scene");
   }
}