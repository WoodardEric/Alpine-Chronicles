using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private PlayerClass player;

    public GameObject keyOne, keyTwo, keyThree;
    public Text Apples, Cheese, HP, STR, SP; 

    [SerializeField]
    int a,b,c,d,e;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerClass.Instance;
    }
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
