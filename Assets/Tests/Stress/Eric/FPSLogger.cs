using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLogger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("FPS: " + 1.0f / Time.deltaTime);
    }
}
