/*
 * Filename: EnemyStressTest.cs
 * Developer: Gus
 * Purpose: Script solely for use in the stress test level to test the number 
 * of enemies that unity may render simultaneously at a given time.
 */

using UnityEngine;

/// <summary>
/// Calls SpawnDude to spawn enemies in the given scene to stress test the Unity Engine.
/// </summary>
public class EnemyStressTest : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy = null;

    /// <summary>
    /// Checks to spawn enemies.
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) // press the 1 key on the keyboard to spawn a test enemy at a random point in the stresstest level.
        {
            SpawnDude(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // press the 2 key on the keyboard to spawn 10 test enemies at a random points in the stresstest level.
        {
            SpawnDude(10);
        }
    }

    /// <summary>
    /// Spawns an enemy at a random location in the given scene.
    /// </summary>
    /// <param name="count"></param>
    private void SpawnDude(int count)
    {
        for(int i = 0; i < count; i++)
        {
            GameObject foo = Instantiate(enemy, new Vector3(Random.Range(-50.0f, 50.0f), Random.Range(-50.0f, 50.0f), 0.0f), Quaternion.identity);
        }
    }
}