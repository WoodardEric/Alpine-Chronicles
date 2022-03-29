using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class InventoryTesting
{
    GameObject gameObject;
    PlayerClass player;
    Animator animator;

    // Arrange
    [SetUp]
    public void Setup()
    {
        // Create game object with player script
        gameObject = new GameObject();
        gameObject.AddComponent<PlayerInventory>();
        player = gameObject.AddComponent<PlayerClass>();
        animator = gameObject.AddComponent<Animator>();
        player.animator = animator;
        player.SetComponents();
    }
    
    [Test]
    public void InvSizeTest()
    {
        Assert.IsFalse(player.RemoveInvItem(0));

        Assert.AreEqual(0, player.GetNumInvItems());
        ItemFactory factory = new KatanaFactory();
        for (int i = 0; i < player.GetMaxItems(); ++i)
        {
            ItemClass item = factory.GetItemClass();
            player.AddInvItem(item);
        }

        Assert.AreEqual(20, player.GetNumInvItems());

        ItemClass outsideItem = factory.GetItemClass();
        Assert.IsFalse(player.AddInvItem(outsideItem));

        Assert.AreEqual(20, player.GetNumInvItems());
    }

    [TearDown]
    public void Teardown()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}
