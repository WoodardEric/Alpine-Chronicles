using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStressTest : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) //press the 1 key on the keyboard to spawn a test enemy at a random point in the stresstest level.
        {
            SpawnDude(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //press the 2 key on the keyboard to spawn 10 test enemies at a random points in the stresstest level.
        {
            SpawnDude(10);
        }
    }

    private void SpawnDude(int count)
    {
        for(int i = 0; i < count; i++)
        {
            GameObject foo = Instantiate(enemy, new Vector3(Random.Range(-50.0f, 50.0f), Random.Range(-50.0f, 50.0f), 0.0f), Quaternion.identity);
        }
    }
}
