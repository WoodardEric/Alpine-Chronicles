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
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnDude(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
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
