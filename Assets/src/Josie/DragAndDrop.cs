using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public int originIndex;
    private Vector2 originPos;
    private int switchIndex;
    GameObject inventory;
    GameObject inventoryM;
    float right, left, up, down;
    GameObject draggedItem;
    PlayerClass player;
    Rigidbody2D rgdb;
    public GameObject cameraObj;
    public Camera invcamera;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        rgdb = this.GetComponent<Rigidbody2D>();
        player = PlayerClass.Instance;
        cameraObj = GameObject.Find("InvItems");
        invcamera = cameraObj.GetComponent<Camera>();
        switchIndex = -1;
    }
    private void Update()
    {
        if (this.rgdb.IsSleeping())
        {
            this.rgdb.WakeUp();
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        originPos = new Vector2(rectTransform.localPosition.x, rectTransform.localPosition.y);
        //canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        draggedItem = eventData.pointerDrag;
        rectTransform.anchoredPosition += eventData.delta;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        inventory = GameObject.Find("Inventory");
        inventoryM = GameObject.Find("InventoryMenu");
        right = inventory.GetComponent<RectTransform>().rect.width - (inventoryM.GetComponent<RectTransform>().rect.width / 1.4f);
        left = -inventory.GetComponent<RectTransform>().rect.position.x - (inventoryM.GetComponent<RectTransform>().rect.width / 2) - 5;
        up = -inventory.GetComponent<RectTransform>().rect.position.y + (inventoryM.GetComponent<RectTransform>().rect.height / 2);
        down = -inventory.GetComponent<RectTransform>().rect.position.y - (inventoryM.GetComponent<RectTransform>().rect.height / 2);
        //width = test.GetComponent<RectTransform>().rect.position.x + (test.GetComponent<RectTransform>().rect.width / 2);
        Debug.Log("Right: " + right + "Left: " + left + "Up: " + up + "Down: " + down + "position: " + eventData.position.x);
        if (eventData.position.x > right || eventData.position.x < left || eventData.position.y > up || eventData.position.y < down)
        {
            player.inventory.RemoveItem(originIndex);
            Destroy(draggedItem);
        }
        Debug.Log("POSITION IN CAMERA: " + invcamera.WorldToScreenPoint(eventData.position));
        Vector3 camPos = invcamera.WorldToScreenPoint(eventData.position);
        // Row One
        if (camPos.x > 950f && camPos.y > 500f && camPos.x < 1050 && camPos.y < 600)
        {
            Debug.Log("MADE IT 0");
            switchIndex = 0;
        }
        else if (camPos.x > 1050f && camPos.y > 500f && camPos.x < 1150 && camPos.y < 600)
        {
            Debug.Log("MADE IT 1");
            switchIndex = 1;
        }
        else if (camPos.x > 1150f && camPos.y > 500f && camPos.x < 1280 && camPos.y < 600)
        {
            Debug.Log("MADE IT 2");
            switchIndex = 2;
        }
        else if (camPos.x > 1280f && camPos.y > 500f && camPos.x < 1400 && camPos.y < 600)
        {
            Debug.Log("MADE IT 3");
            switchIndex = 3;
        }
        else if (camPos.x > 1400f && camPos.y > 500f && camPos.x < 1500 && camPos.y < 600)
        {
            Debug.Log("MADE IT 4");
            switchIndex = 4;
        }

        // Row Two
        else if (camPos.x > 950f && camPos.y > 382f && camPos.x < 1050 && camPos.y < 500)
        {
            Debug.Log("MADE IT 1_0");
            switchIndex = 5;
        }
        else if (camPos.x > 1050f && camPos.y > 382f && camPos.x < 1150 && camPos.y < 500)
        {
            Debug.Log("MADE IT 1_1");
            switchIndex = 6;
        }
        else if (camPos.x > 1150f && camPos.y > 382f && camPos.x < 1280 && camPos.y < 500)
        {
            Debug.Log("MADE IT 1_2");
            switchIndex = 7;
        }
        else if (camPos.x > 1280f && camPos.y > 382f && camPos.x < 1400 && camPos.y < 500)
        {
            Debug.Log("MADE IT 1_3");
            switchIndex = 8;
        }
        else if (camPos.x > 1400f && camPos.y > 382f && camPos.x < 1500 && camPos.y < 500)
        {
            Debug.Log("MADE IT 1_4");
            switchIndex = 9;
        }


        // Row Three
        else if (camPos.x > 950f && camPos.y > 260f && camPos.x < 1050 && camPos.y < 382)
        {
            Debug.Log("MADE IT 2_0");
            switchIndex = 10;
        }
        else if (camPos.x > 1050f && camPos.y > 260f && camPos.x < 1150 && camPos.y < 382)
        {
            Debug.Log("MADE IT 2_1");
            switchIndex = 11;
        }
        else if (camPos.x > 1150f && camPos.y > 260f && camPos.x < 1280 && camPos.y < 382)
        {
            Debug.Log("MADE IT 2_2");
            switchIndex = 12;
        }
        else if (camPos.x > 1280f && camPos.y > 260f && camPos.x < 1400 && camPos.y < 382)
        {
            Debug.Log("MADE IT 2_3");
            switchIndex = 13;
        }
        else if (camPos.x > 1400f && camPos.y > 260f && camPos.x < 1500 && camPos.y < 382)
        {
            Debug.Log("MADE IT 2_4");
            switchIndex = 14;
        }


        // Row Four
        else if (camPos.x > 950f && camPos.y > 150f && camPos.x < 1050 && camPos.y < 260f)
        {
            Debug.Log("MADE IT 3_0");
            switchIndex = 15;
        }
        else if (camPos.x > 1050f && camPos.y > 150f && camPos.x < 1150 && camPos.y < 260f)
        {
            Debug.Log("MADE IT 3_1");
            switchIndex = 16;
        }
        else if (camPos.x > 1150f && camPos.y > 150f && camPos.x < 1280 && camPos.y < 260f)
        {
            Debug.Log("MADE IT 3_2");
            switchIndex = 17;
        }
        else if (camPos.x > 1280f && camPos.y > 150f && camPos.x < 1400 && camPos.y < 260f)
        {
            Debug.Log("MADE IT 3_3");
            switchIndex = 18;
        }
        else if (camPos.x > 1400f && camPos.y > 150f && camPos.x < 1500 && camPos.y < 260f)
        {
            Debug.Log("MADE IT 3_4");
            switchIndex = 19;
        }

        if ((switchIndex != -1) && (!player.inventory.SwitchItems(originIndex, switchIndex)))
        {
            rectTransform.localPosition = originPos;
        }
        else
        {
            inventoryM.GetComponent<inventoryMenu>().DestInventory();
            inventoryM.GetComponent<inventoryMenu>().CreateInventory(false);
        }
        //canvasGroup.blocksRaycasts = true;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("MADE IT");
    }
}