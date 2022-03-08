using UnityEngine;

public class AudioStress : MonoBehaviour
{
    public GameObject audioManager;
    public KeyCode key = KeyCode.Z;
    private  bool playsounds = false;
 
    void Update()
    {
        if (Input.GetKey(key))
        {
            playsounds = !playsounds;
        }

        if (playsounds)
        {
            for (int i = 0; i < 100; ++i)
            {
                audioManager.SendMessage("PlaySound");
                audioManager.SendMessage("PlaySound");
                audioManager.SendMessage("PlaySound");
                audioManager.SendMessage("PlaySound");
            }
        }
    }
}
