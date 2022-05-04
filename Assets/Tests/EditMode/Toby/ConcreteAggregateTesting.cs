// using System.Collections;
// using System.Collections.Generic;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;

// public class ConcreteAggregateTesting
// {
//     ConcreteAggregate testAggregate = null;

//     [SetUp]
//     public void Setup()
//     {
//         testAggregate = new ConcreteAggregate();
//     }
//     // A Test behaves as an ordinary method
//     [Test]
//     public void AggregateBoundaries()
//     {
//         Assert.IsFalse(testAggregate.RemoveItem(0));

//         int i;
//         for (i = 0; i < 20; ++i)
//         {
//             testAggregate[i] = i;
//             Assert.AreEqual(i + 1, testAggregate.count);
//         }

//         testAggregate[i] = i;
//         Assert.AreEqual(20, testAggregate.count);

//         Assert.IsFalse(testAggregate.RemoveItem(-1));
//         Assert.IsFalse(testAggregate.RemoveItem(21));
//         Assert.IsFalse(testAggregate.RemoveItem(20));
//         Assert.IsTrue(testAggregate.RemoveItem(10));

//         Assert.AreEqual(19, testAggregate.count);
//     }

//     [Test]
//     public void IteratorTesting()
//     {
//         Iterator it = testAggregate.CreateIterator();

//         Assert.IsTrue(it.First() == null);
//         Assert.IsTrue(it.Next() == null);

//         for (int i = 0; i < 15; ++i)
//         {
//             testAggregate[i] = i;
//         }

//         Assert.IsTrue(it.First() != null);
//         int tempCount = 0;

//         while (!it.IsDone())
//         {
//             int tempInt = (int) it.CurrentItem();
//             Assert.AreEqual(tempCount, tempInt);
//             ++tempCount;
//             it.Next();
//         }

//         Assert.IsTrue(it.IsDone());
//         Assert.IsTrue(it.CurrentItem() == null);
//         Assert.AreEqual(15, tempCount);
//     }

//     [TearDown]
//     public void Teardown()
//     {
//         testAggregate = null;
//     }
// }
