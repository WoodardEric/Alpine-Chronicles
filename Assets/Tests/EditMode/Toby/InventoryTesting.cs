using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InventoryTesting
{
    GameObject gameObject;
    PlayerClass player;

    // Arrange
    [SetUp]
    public void Setup()
    {
        // Create game object with player script
        gameObject = new GameObject();
        gameObject.AddComponent<InventoryClass>();
        player = gameObject.AddComponent<PlayerClass>();
        player.setInventory();
    }
    
    [Test]
    public void InvSizeTest()
    {
        Assert.IsFalse(player.removeInvItem(0));

        Assert.AreEqual(0, player.getNumInvItems());

        for (int i = 0; i < player.getMaxItems(); ++i)
        {
            GameObject obj = new GameObject();
            ItemClass item = obj.AddComponent<ItemClass>();
            player.addInvItem(item);
        }

        Assert.AreEqual(20, player.getNumInvItems());

        GameObject outsideObj = new GameObject();
        ItemClass outsideItem = outsideObj.AddComponent<ItemClass>();
        Assert.IsFalse(player.addInvItem(outsideItem));

        Assert.AreEqual(20, player.getNumInvItems());
    }

    [TearDown]
    public void Teardown()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}
