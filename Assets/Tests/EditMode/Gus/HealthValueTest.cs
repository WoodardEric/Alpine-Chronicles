using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class HealthValueTest
    {
        [Test]
        public void EnemyHealth()
        {
            float min = 0.0f;
            float max = 100.0f;

            EnemyGruntBug[] enemyArray = GameObject.FindObjectsOfType<EnemyGruntBug>();

            for(int i = 0; i < enemyArray.Length; i++)
            {
                Assert.AreEqual(true, enemyArray[i].GetEnemyHealth() >= Mathf.Min(min, max) && enemyArray[i].GetEnemyHealth() <= Mathf.Max(min, max));
            }
        }
    }
}