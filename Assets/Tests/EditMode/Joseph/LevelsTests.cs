using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LevelsTests
{
   [Test]
   public void ChangeSceneToFrom()
   {
      //Get a hold of a LevelManager Instance;
      LevelManager LM = LevelManager.Instance;

      LM.changeScene(1,2);
      Assert.AreEqual(true,LM.goodScene);

      LM.changeScene(1,3);
      Assert.AreEqual(false,LM.goodScene);

      LM.changeScene(1,0);
      Assert.AreEqual(false,LM.goodScene);

      LM.changeScene(0,1);
      Assert.AreEqual(false,LM.goodScene);

      LM.changeScene(3,2);
      Assert.AreEqual(false,LM.goodScene);
   }
}