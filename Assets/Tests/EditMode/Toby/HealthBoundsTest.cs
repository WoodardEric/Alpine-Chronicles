using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

public class HealthBoundsTest
{
    GameObject gameObject;
    PlayerTestingHelper player;

    // Arrange
    [SetUp]
    public void Setup()
    {
        // Create game object with player script
        gameObject = new GameObject();
        player = gameObject.AddComponent<PlayerTestingHelper>();
    }
    
    [Test]
    public void OverhealTest()
    {
        // Arrange
        // Set health just inside boundary
        player.setHealth(99);

        // Act
        // Add 2 to the players health to see if it will go over 100
        player.updateHealth(2);

        // Assert
        Assert.AreEqual(100, player.getHealth());

        // Arrange
        // Checking same as above, but on the boundary of 100
        player.setHealth(100);

        // Act
        // Add 1 to player health
        player.updateHealth(1);

        // Assert
        Assert.AreEqual(100, player.getHealth());

        // Arrange
        // Checking same as above, but just outside the boundary
        player.setHealth(101);

        // Act
        // Add 1 to player health
        player.updateHealth(1);

        // Assert
        Assert.AreEqual(100, player.getHealth());
    }

    [Test]
    public void DamageTest()
    {
        // Arrange
        player.setHealth(1);

        // Act
        player.updateHealth(-2);

        // Assert
        Assert.AreEqual(0, player.getHealth());

        // Arrange
        player.setHealth(0);

        // Act
        player.updateHealth(-1);

        // Assert
        Assert.AreEqual(0, player.getHealth());

        // Arrange
        player.setHealth(-1);

        // Act
        player.updateHealth(-1);

        // Assert
        Assert.AreEqual(0, player.getHealth());
    }

    [Test]
    public void bcModeHealTest()
    {
        player.startBCMode("GoBig");
        // Arrange
        player.setHealth(99);

        // Act
        player.updateHealth(2);

        // Assert
        Assert.AreEqual(100, player.getHealth());

        // Arrange
        player.setHealth(100);

        // Act
        player.updateHealth(1);

        // Assert
        Assert.AreEqual(100, player.getHealth());

        // Arrange
        player.setHealth(101);

        // Act
        player.updateHealth(1);

        // Assert
        Assert.AreEqual(100, player.getHealth());
    }

    [Test]
    public void bcModeDamageTest()
    {
        player.startBCMode("GoBig");
        // Arrange
        player.setHealth(1);

        // Act
        player.updateHealth(-2);

        // Assert
        Assert.AreEqual(-1, player.getHealth());

        // Arrange
        player.setHealth(0);

        // Act
        player.updateHealth(-1);

        // Assert
        Assert.AreEqual(-1, player.getHealth());

        // Arrange
        player.setHealth(Int32.MinValue + 1);

        // Act
        player.updateHealth(-1);

        // Assert
        Assert.AreEqual(Int32.MinValue, player.getHealth());

        // Arrange
        player.setHealth(Int32.MinValue);

        // Act
        player.updateHealth(-1);

        // Assert
        Assert.AreEqual(Int32.MinValue, player.getHealth());

        // Arrange
        player.setHealth(Int32.MinValue);

        // Act
        player.updateHealth(-50);

        // Assert
        Assert.AreEqual(Int32.MinValue, player.getHealth());
    }

    [TearDown]
    public void Teardown()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}
