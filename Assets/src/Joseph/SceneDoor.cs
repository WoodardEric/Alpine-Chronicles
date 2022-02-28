using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDoor : Door
{

   public int toScene;

   override public void interact()
   {
      SceneManager.LoadScene(toScene);
   }
}