using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CollisionStressTest
{
   // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
   // `yield return null;` to skip a frame.
   [UnityTest]
   public IEnumerator WallCollision()
   {
      GameObject gameObject = new GameObject();
      Vector3 intialPos = new Vector3(0f,-4f,0f);
      gameObject.transform.position = intialPos;

      //Act
      
      // Use the Assert class to test conditions.
      // Use yield to skip a frame.
      yield return null;
   }
}