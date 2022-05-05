// using System.Collections;
// using System.Collections.Generic;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;
// using System;

// public class HealthBoundsTest
// {
//     GameObject gameObject;
//     PlayerTestingHelper player;
//     Animator animator;

//     // Arrange
//     [SetUp]
//     public void Setup()
//     {
//         // Create game object with player script
//         gameObject = new GameObject();
//         player = gameObject.AddComponent<PlayerTestingHelper>();
//         animator = gameObject.AddComponent<Animator>();
//         player.animator = animator;
//     }
    
//     [Test]
//     public void OverhealTest()
//     {
//         // Arrange
//         // Set health just inside boundary
//         player.setHealth(99);

//         // Act
//         // Add 2 to the players health to see if it will go over 100
//         player.UpdateHealth(2);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(100, player.GetHealth());

//         // Arrange
//         // Checking same as above, but on the boundary of 100
//         player.setHealth(100);

//         // Act
//         // Add 1 to player health
//         player.UpdateHealth(1);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(100, player.GetHealth());

//         // Arrange
//         // Checking same as above, but just outside the boundary
//         player.setHealth(101);

//         // Act
//         // Add 1 to player health
//         player.UpdateHealth(1);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(100, player.GetHealth());
//     }

//     [Test]
//     public void DamageTest()
//     {
//         // Arrange
//         player.setHealth(1);

//         // Act
//         player.UpdateHealth(-2);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(0, player.GetHealth());

//         // Arrange
//         player.setHealth(0);

//         // Act
//         player.UpdateHealth(-1);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(0, player.GetHealth());

//         // Arrange
//         player.setHealth(-1);

//         // Act
//         player.UpdateHealth(-1);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(0, player.GetHealth());
//     }

//     [Test]
//     public void bcModeHealTest()
//     {
//         player.StartBCMode("GoBig");
//         // Arrange
//         player.setHealth(99);

//         // Act
//         player.UpdateHealth(2);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(100, player.GetHealth());

//         // Arrange
//         player.setHealth(100);

//         // Act
//         player.UpdateHealth(1);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(100, player.GetHealth());

//         // Arrange
//         player.setHealth(101);

//         // Act
//         player.UpdateHealth(1);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(100, player.GetHealth());
//     }

//     [Test]
//     public void bcModeDamageTest()
//     {
//         player.StartBCMode("GoBig");
//         // Arrange
//         player.setHealth(1);

//         // Act
//         player.UpdateHealth(-2);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(-1, player.GetHealth());

//         // Arrange
//         player.setHealth(0);

//         // Act
//         player.UpdateHealth(-1);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(-1, player.GetHealth());

//         // Arrange
//         player.setHealth(Int32.MinValue + 1);

//         // Act
//         player.UpdateHealth(-1);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(Int32.MinValue, player.GetHealth());

//         // Arrange
//         player.setHealth(Int32.MinValue);

//         // Act
//         player.UpdateHealth(-1);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(Int32.MinValue, player.GetHealth());

//         // Arrange
//         player.setHealth(Int32.MinValue);

//         // Act
//         player.UpdateHealth(-50);
//         player.setUpdateNum();

//         // Assert
//         Assert.AreEqual(Int32.MinValue, player.GetHealth());
//     }

//     [TearDown]
//     public void Teardown()
//     {
//         GameObject.DestroyImmediate(gameObject);
//     }
// }
