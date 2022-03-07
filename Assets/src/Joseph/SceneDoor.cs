using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDoor : Door
{

   public int toScene;
   public int fromScene;
   LevelManager LM = LevelManager.LMInstance;

   override public void interact()
   {
      this.LM.changeScene(toScene,fromScene);
   }
}