using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDoor : Door
{
   public int toScene;
   public int fromScene;
   //LevelManager LM = LevelManager.Instance;

   override public void open()
   {
      LevelManager.Instance.changeScene(toScene,fromScene);
      //LM.changeScene(toScene,fromScene);
      Debug.Log("Change Scene");
   }
}