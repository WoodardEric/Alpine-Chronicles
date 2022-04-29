using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private PlayerClass hero;

    public GameObject keyOne, keyTwo, keyThree;
    public Text Apples, Cheese, HP, STR, SP; 

    [SerializeField]
    int a,b,c,d,e;
    // Start is called before the first frame update
    void Start()
    {
        hero = (PlayerClass)FindObjectOfType(typeof(PlayerClass));
        Apples.text = hero.numApples.ToString();
        Cheese.text = hero.numCheese.ToString();
        HP.text = hero.numHealthPots.ToString();
        STR.text = hero.numStrPots.ToString();
        SP.text = hero.numSpPots.ToString();
        Apples.text = hero.numApples.ToString();
        Cheese.text = hero.numCheese.ToString();
        HP.text = hero.numHealthPots.ToString();
        STR.text = hero.numStrPots.ToString();
        SP.text = hero.numSpPots.ToString();
    }
    void Awake()
    {
        hero = (PlayerClass)FindObjectOfType(typeof(PlayerClass));
        Apples.text = hero.numApples.ToString();
        Cheese.text = hero.numCheese.ToString();
        HP.text = hero.numHealthPots.ToString();
        STR.text = hero.numStrPots.ToString();
        SP.text = hero.numSpPots.ToString();
        Apples.text = hero.numApples.ToString();
        Cheese.text = hero.numCheese.ToString();
        HP.text = hero.numHealthPots.ToString();
        STR.text = hero.numStrPots.ToString();
        SP.text = hero.numSpPots.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Apples.text = hero.numApples.ToString();
        Cheese.text = hero.numCheese.ToString();
        HP.text = hero.numHealthPots.ToString();
        STR.text = hero.numStrPots.ToString();
        SP.text = hero.numSpPots.ToString();
        a = hero.numApples;
        b = hero.numCheese;
        c = hero.numHealthPots;
        d = hero.numStrPots;
        e = hero.numSpPots;
        if(hero.key1)
        {
            keyOne.SetActive(true);
        }
        if(hero.key2)
        {
            keyTwo.SetActive(true);
        }
        if(hero.key3)
        {
            keyThree.SetActive(true);
        }
        
        
    }
}
