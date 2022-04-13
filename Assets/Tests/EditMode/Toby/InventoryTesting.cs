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
        player = gameObject.AddComponent<PlayerClass>();
        animator = gameObject.AddComponent<Animator>();
        player.animator = animator;
        player.SetComponents();
    }
    
    [Test]
    public void InvSizeTest()
    {
        // Check whether an item can be removed from an empty inventory
        Assert.IsFalse(player.inventory.RemoveItem(0));
        // Verify that inventory didn't increase
        Assert.AreEqual(0, player.inventory.count);

        // Fill the entirety of the inventory
        ItemFactory factory = new KatanaFactory();
        for (int i = 0; i < player.inventory.GetMaxItems(); ++i)
        {
            ItemClass item = factory.GetItemClass();
            player.inventory.AddItem(item);
        }

        // Verify that the max inventory size works properly
        Assert.AreEqual(20, player.inventory.count);

        // Try to add another item to a full inventory to see if it fails gravefully
        ItemClass outsideItem = factory.GetItemClass();
        Assert.IsFalse(player.inventory.AddItem(outsideItem));

        // Ensure that the inventory size didn't go above max
        Assert.AreEqual(20, player.inventory.count);
    }


    [Test]
    public void InvSwitchTest()
    {
        // Add a few items to the player inventory
        player.inventory.AddItem(new KatanaFactory().GetItemClass());
        player.inventory.AddItem(new WeaponTwoFactory().GetItemClass());
        player.inventory.AddItem(new WeaponThreeFactory().GetItemClass());

        // Store the initial values of the items at each index of the inventory
        ItemClass initialZero = player.inventory.GetItem(0);
        ItemClass initialOne = player.inventory.GetItem(1);
        ItemClass initialTwo = player.inventory.GetItem(2);

        // Verify that all items are as they should be
        Assert.AreEqual(initialZero.itemName, new KatanaFactory().GetItemClass().itemName);
        Assert.AreEqual(initialOne.itemName, new WeaponTwoFactory().GetItemClass().itemName);
        Assert.AreEqual(initialTwo.itemName, new WeaponThreeFactory().GetItemClass().itemName);

        // Try to switch items where one index is less than 0 or greater than current inventory size
        Assert.IsFalse(player.inventory.SwitchItems(-1, 1));
        Assert.IsFalse(player.inventory.SwitchItems(1, -1));
        Assert.IsFalse(player.inventory.SwitchItems(3, 1));
        Assert.IsFalse(player.inventory.SwitchItems(1, 3));

        // Attempt to switch two items in inventory
        Assert.IsTrue(player.inventory.SwitchItems(0, 2));

        // Verify that the two items switched place in the inventory
        Assert.AreEqual(initialTwo.itemName, player.inventory.GetItem(0).itemName);
        Assert.AreEqual(initialZero.itemName, player.inventory.GetItem(2).itemName);
    }


    [Test]
    public void SwitchEquippedTest()
    {
        bool found;
        ItemClass value;

        //Try switching items when player has no inventory or equipped item
        (found, value) = player.inventory.SwitchEquipped(0, player.equippedWeapon);
        Assert.IsFalse(found);
        Assert.IsTrue(value == null);

        // Add 2 items to player inventory
        player.inventory.AddItem(new WeaponThreeFactory().GetItemClass());
        player.inventory.AddItem(new WeaponTwoFactory().GetItemClass());

        // Give the player a weapon to equip and verify it is correct
        player.equippedWeapon = new KatanaFactory().GetItemClass();
        Assert.AreEqual(new KatanaFactory().GetItemClass().strength, player.equippedWeapon.strength);
        Assert.AreEqual(new KatanaFactory().GetItemClass().itemName, player.equippedWeapon.itemName);

        // Try to switch the equipped weapon to index -1 (below the bounds) of the inventory
        (found, value) = player.inventory.SwitchEquipped(-1, new WeaponTwoFactory().GetItemClass());
        Assert.IsFalse(found);
        Assert.IsTrue(value == null);

        // Try to switch the equipped weapon to index 20 (above the bounds) of the inventory
        (found, value) = player.inventory.SwitchEquipped(20, new WeaponTwoFactory().GetItemClass());
        Assert.IsFalse(found);
        Assert.IsTrue(value == null);

        // Switch player's equipped item (Katana) with the first item in inventory (Weapon 3)
        (found, value) = player.inventory.SwitchEquipped(0, player.equippedWeapon);
        player.equippedWeapon = value;
        Assert.IsTrue(found);
        Assert.IsTrue(value.itemName == new WeaponThreeFactory().GetItemClass().itemName);
        Assert.AreEqual(new WeaponThreeFactory().GetItemClass().itemName, player.equippedWeapon.itemName);
        Assert.AreEqual(new WeaponThreeFactory().GetItemClass().strength, player.equippedWeapon.strength);

        Assert.AreEqual(new KatanaFactory().GetItemClass().itemName, player.inventory.GetItem(0).itemName);
        Assert.AreEqual(new KatanaFactory().GetItemClass().strength, player.inventory.GetItem(0).strength);

        // Try to switch two null items
        (found, value) = player.inventory.SwitchEquipped(7, null);
        Assert.IsFalse(found);
        Assert.IsTrue(value == null);

        // Get current number of inventory items
        int invCount = player.inventory.count;
        // Remove the player's equipped item and temporarily store the value of the first inventory item
        player.equippedWeapon = null;
        ItemClass tempItem = player.inventory.GetItem(1);
        // Test moving an item from inventory to equip slot when equip slot is empty (reduce inventory size)
        (found, value) = player.inventory.SwitchEquipped(1, player.equippedWeapon);
        player.equippedWeapon = value;
        Assert.IsTrue(found);
        Assert.AreEqual(tempItem.itemName, value.itemName);
        Assert.AreEqual(--invCount, player.inventory.count);

        // Attempt to add an item at an index greater than the current number of items
        (found, value) = player.inventory.SwitchEquipped(8, player.equippedWeapon);
        player.equippedWeapon = value;

        // Add item to inventory
        Assert.AreEqual(++invCount, player.inventory.count);
        Assert.IsTrue(player.equippedWeapon == null);

        // Attempt to add an item at an index greater than the current number of items
        player.equippedWeapon = new WeaponFourFactory().GetItemClass();
        (found, value) = player.inventory.SwitchEquipped(9, player.equippedWeapon);
        player.equippedWeapon = value;

        // Add item to inventory
        Assert.AreEqual(++invCount, player.inventory.count);
        Assert.IsTrue(player.equippedWeapon == null);
    }


    [Test]
    public void RemovalTesting()
    {
        // Check for errors when inventory is empty
        Assert.IsFalse(player.inventory.RemoveItem("TestItemName"));
        
        // Add items to player inventory
        player.inventory.AddItem(new WeaponTwoFactory().GetItemClass());
        player.inventory.AddItem(new WeaponThreeFactory().GetItemClass());
        player.inventory.AddItem(new WeaponFourFactory().GetItemClass());
        player.inventory.AddItem(new WeaponFiveFactory().GetItemClass());
        player.inventory.AddItem(new KatanaFactory().GetItemClass());

        // Check for errors when an item doesn't exist in the inventory
        Assert.IsFalse(player.inventory.RemoveItem("AnotherTestItem"));

        // Check whether items can be properly found
        Assert.IsTrue(player.inventory.RemoveItem("Katana"));
        Assert.IsTrue(player.inventory.RemoveItem("WeaponFour"));
    }


    [TearDown]
    public void Teardown()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}
