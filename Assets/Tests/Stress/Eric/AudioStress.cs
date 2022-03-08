using UnityEngine;

public class AudioStress : MonoBehaviour
{
    public GameObject audioManager;
    private KeyCode stop = KeyCode.Alpha0;
    private KeyCode ten = KeyCode.Alpha1;
    private KeyCode hundred = KeyCode.Alpha2;
    private KeyCode thousand = KeyCode.Alpha3;
    private KeyCode hundredThousand = KeyCode.Alpha4;
    private int num = 0;

    public  bool playsounds = false;
    
    public void PlaySounds(int num)
    {
        for(int i = 0; i < num; ++i)
        {
            audioManager.SendMessage("PlaySound");
        }
    }

    void Update()
    {
        if (Input.GetKey(stop))
        {
            num = 0;
        }
        else if(Input.GetKey(ten))
        {
            num = 10;
        }
        else if (Input.GetKey(hundred))
        {
            num = 100;
        }
        else if (Input.GetKey(thousand))
        {
            num = 1000;
        }
        else if (Input.GetKey(hundredThousand))
        {
            num = 10000;
        }


            for (int i = 0; i < num; ++i)
            {
                audioManager.SendMessage("PlaySound");
            }
        
    }
}
