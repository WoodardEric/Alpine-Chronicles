using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class CollisionStressTest
{
   [SetUp]
   public void setup()
   {
      SceneManager.LoadScene("JosephTestScene");
   }
   [UnityTest]
   public IEnumerator WallCollision()
   {
      GameObject wall = GameObject.Find("Wall");
      StressObject testObject = StressObject.Instance;
      Vector2 initialPos = new Vector2(0f,0f);
      float speed=1f;

      //Act
      while(testObject.transform.position.y < wall.transform.position.y)
      {
         testObject.SetPos(initialPos);
         testObject.speed=speed;
         Debug.Log("Speed = "+speed);
         speed = speed * 1.05f;
         yield return new WaitForSeconds(Mathf.Ceil(4f/speed));
     }
  }
}