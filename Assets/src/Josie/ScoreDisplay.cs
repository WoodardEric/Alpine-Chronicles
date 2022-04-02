using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text ScoreText;
    
    public PlayerClass Player = null;

    // Start is called before the first frame update
    void Start()
    {
        Player = PlayerClass.Instance;
    }

    // Update is called once per frame
    
    void Update()
    {
        int Score = Player.GetScore();
        ScoreText.text = Score.ToString();
    }
}
