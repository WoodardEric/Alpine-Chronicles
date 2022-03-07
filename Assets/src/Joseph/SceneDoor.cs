using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDoor : Door
{

   public int toScene;
   public int fromScene;
   LevelManager LM = LevelManager.Instance;

   override public void interact()
   {
      LM.changeScene(toScene,fromScene);
   }
}