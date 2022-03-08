using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStress : MonoBehaviour
{
    public GameObject audioManager;

    void Start()
    {
        audioManager.SendMessage("PlaySound");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
