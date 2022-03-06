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
      //public GameObject brick;
      //GameObject brick = new GameObject();
      //brick.AddComponent<BoxCollider2D>();
      //brick.transform.position = new Vector2(0f,4f);
      GameObject gameObject = new GameObject();
      gameObject.AddComponent<Rigidbody2D>();
      gameObject.AddComponent<BoxCollider2D>();
      gameObject.GetComponent<Rigidbody2D>().gravityScale=0f;
      Vector2 intialPos = new Vector2(0f,3f);
      gameObject.transform.position = intialPos;
      yield return null;
      float speed=1f;

      //Act
     //while(gameObject.transform.position.y < 4f)
     //{
         Vector2 newPos = new Vector2(0f,speed+intialPos.y);
         gameObject.GetComponent<Rigidbody2D>().MovePosition(newPos);
         yield return null;
         Debug.Log("Speed = "+speed);
         speed = speed * 1.05f;
     //}

      // Use the Assert class to test conditions.
      Vector3 expected = new Vector3(0f,4f,0f);
      Assert.AreEqual(expected,gameObject.transform.position);

      // Use yield to skip a frame.
      yield return null;
  }
}