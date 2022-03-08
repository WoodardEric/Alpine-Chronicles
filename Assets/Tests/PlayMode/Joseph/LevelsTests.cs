using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LevelsTests
{
   [UnityTest]
   public IEnumerator ChangeSceneToFrom()
   {
      //Get a hold of a LevelManager Instance;
      LevelManager LM = LevelManager.Instance;
      //Assert.IsNotNull(LM);
      LM.test = true;

      LM.changeScene(1,2);
      Assert.AreEqual(1,LM.goodScene);

      LM.changeScene(1,3);
      Assert.AreEqual(0,LM.goodScene);
 
      LM.changeScene(1,0);
      Assert.AreEqual(0,LM.goodScene);

      LM.changeScene(0,1);
      Assert.AreEqual(0,LM.goodScene);

      LM.changeScene(3,2);
      Assert.AreEqual(0,LM.goodScene);
   }
}