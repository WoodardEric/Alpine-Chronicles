using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryMenu : MonoBehaviour
{
    public GameObject bossKey;
    public GameObject healthApple;
    public GameObject healthCheese;
    public GameObject healthPotion;
    public GameObject katana;
    public GameObject masterSword;
    public GameObject roomKeyOne;
    public GameObject roomKeyTwo;
    public GameObject speedPotion;
    public GameObject strengthPotion;
    public GameObject weaponEight;
    public GameObject weaponFive;
    public GameObject weaponFour;
    public GameObject weaponNine;
    public GameObject weaponSeven;
    public GameObject weaponSix;
    public GameObject weaponThree;
    public GameObject weaponTwo;
    public GameObject EquipWeapon;
    public GameObject EquipUtility;
    
    public static bool inventroyCalled = false;
    static GameObject []items = new GameObject[20];
    static GameObject equippedWeapon;
    static GameObject equippedItem;
    static int numItems = 0;

    public GameObject inventory;
    PlayerClass player = null;
    float invWidth;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerClass.Instance;
    }

    public void inventoryButton()
    {
        Debug.Log("Inventory menu");
        inventory.SetActive(true);
        Time.timeScale = 0f; 
        inventroyCalled = true;
        player.IsInteracting(true);
        CreateInventory(true);
    }

    public void CreateInventory(bool origin)
    {
        float invWidth;

        if (player.equippedWeapon != null)
        {
            equippedWeapon = getItemImage(player.equippedWeapon.itemName);
            if (origin)
            {
                equippedWeapon.transform.parent = gameObject.transform.GetChild(0).transform;
                invWidth = gameObject.transform.GetChild(0).transform.GetComponent<RectTransform>().rect.width;
            }
            else
            {
                equippedWeapon.transform.parent = gameObject.transform;
                invWidth = gameObject.transform.GetComponent<RectTransform>().rect.width;
            }
            equippedWeapon.GetComponent<DragAndDrop>().originIndex = 21;
            RectTransform rt = equippedWeapon.GetComponent<RectTransform>();
            rt.localScale = new Vector3(1f, 1f, 0f);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, rt.rect.width);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);
            rt.localPosition = new Vector3(rt.localPosition.x -320f, rt.localPosition.y -140, 0f);
        }
        if (player.equippedUtil != null)
        {
            equippedItem = getItemImage(player.equippedUtil.itemName);
            if (origin)
            {
                equippedItem.transform.parent = gameObject.transform.GetChild(0).transform;
                invWidth = gameObject.transform.GetChild(0).transform.GetComponent<RectTransform>().rect.width;
            }
            else
            {
                equippedItem.transform.parent = gameObject.transform;
                invWidth = gameObject.transform.GetComponent<RectTransform>().rect.width;
            }

            equippedItem.GetComponent<DragAndDrop>().originIndex = 22;
            RectTransform rt = equippedItem.GetComponent<RectTransform>();
            rt.localScale = new Vector3(1f, 1f, 0f);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, rt.rect.width);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);
            rt.localPosition = new Vector3(rt.localPosition.x -320f, rt.localPosition.y -385, 0f);
        }

        for (int i = 0; i < player.inventory.count; ++i)
        {
            Debug.Log(player.inventory.GetItem(i).itemName);
            items[numItems++] = getItemImage(player.inventory.GetItem(i).itemName);
            if (origin)
            {
                items[i].transform.parent = gameObject.transform.GetChild(0).transform;
                invWidth = gameObject.transform.GetChild(0).transform.GetComponent<RectTransform>().rect.width;
            }
            else
            {
                items[i].transform.parent = gameObject.transform;
                invWidth = gameObject.transform.GetComponent<RectTransform>().rect.width;
            }
            items[i].GetComponent<DragAndDrop>().originIndex = i;
            RectTransform rt = items[i].GetComponent<RectTransform>();
            rt.localScale = new Vector3(1f, 1f, 0f);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, rt.rect.width);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);
            
            if (i < 5)
            {
                rt.localPosition = new Vector3(-(invWidth / 2.5f) + (i * 150), rt.localPosition.y - 25f, 0f);
            }
            else if (i >= 5 && i < 10)
            {
                rt.localPosition = new Vector3(-(invWidth / 2.5f) + ((i - 5) * 150), rt.localPosition.y - 175f, 0f);
            }
            else if (i >= 10 && i < 15)
            {
                rt.localPosition = new Vector3(-(invWidth / 2.5f) + ((i - 10) * 150), rt.localPosition.y - 325f, 0f);
            }
            else
            {
                rt.localPosition = new Vector3(-(invWidth / 2.5f) + ((i - 15) * 150), rt.localPosition.y - 475f, 0f);
            }
        }
    }

    private GameObject getItemImage(string name)
    {
        if (name == "Katana")
        {
            return Instantiate(katana, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "HealthApple")
        {
            return Instantiate(healthApple, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "BossKey")
        {
            return Instantiate(bossKey, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "HealthCheese")
        {
            return Instantiate(healthCheese, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "HealthPotion")
        {
            return Instantiate(healthPotion, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "MasterSword")
        {
            return Instantiate(masterSword, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "RoomKeyOne")
        {
            return Instantiate(roomKeyOne, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "RoomKeyTwo")
        {
            return Instantiate(roomKeyTwo, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "SpeedPotion")
        {
            return Instantiate(speedPotion, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "StrengthPotion")
        {
            return Instantiate(strengthPotion, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "WeaponEight")
        {
            return Instantiate(weaponEight, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "WeaponFive")
        {
            return Instantiate(weaponFive, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "WeaponFour")
        {
            return Instantiate(weaponFour, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "WeaponNine")
        {
            return Instantiate(weaponNine, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "WeaponSeven")
        {
            return Instantiate(weaponSeven, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "WeaponSix")
        {
            return Instantiate(weaponSix, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "WeaponThree")
        {
            return Instantiate(weaponThree, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        else if (name == "WeaponTwo")
        {
            return Instantiate(weaponTwo, new Vector3(0f,0f,0f), Quaternion.identity);
        }
        return null;
    }

    public void ResumeGame()
    {
        DestInventory();
        inventory.SetActive(false);
        Time.timeScale = 1f; 
        inventroyCalled = false;
        player.IsInteracting(false);
    }

    public void DestInventory()
    {
        Debug.Log("NUM ITEMS" + numItems);
        
        if(equippedWeapon != null)
        {
            Destroy(equippedWeapon);
        }
        if (equippedItem != null)
        {
            Destroy(equippedItem);
        }
        
        if (numItems == 0)
        {
            return;
        }
        Debug.Log("MADE IT " + items[0].name);
        for (int i = 0; i < numItems; ++i)
        {
            Destroy(items[i]);
        }
        numItems = 0;
    }
}
