using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class AttackValueTest
    {
        [Test]
        public void EnemyDamage()
        {
            float min = 0.0f;
            float max = 10.0f;

            EnemyGruntBug[] enemyArray = GameObject.FindObjectsOfType<EnemyGruntBug>();

            for (int i = 0; i < enemyArray.Length; i++)
            {
                Assert.AreEqual(true, enemyArray[i].EnemyDamage >= Mathf.Min(min, max) && enemyArray[i].EnemyDamage <= Mathf.Max(min, max));
            }
        }
    }
}