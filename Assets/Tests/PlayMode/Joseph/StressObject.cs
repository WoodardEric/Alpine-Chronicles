using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressObject : MonoBehaviour
{
    public static StressObject Instance {get; private set;}

    public float speed;
    Vector2 newPos;

    private void Awake()
    {
         if (Instance != null && Instance != this)
          {
               Destroy(this.gameObject);
          }
          else
          {
               Instance = this;
               DontDestroyOnLoad(this);
          }
    }

    void FixedUpdate()
    {
        this.newPos = new Vector2(this.transform.position.x,this.transform.position.y);
        this.newPos.y += (this.speed * Time.deltaTime);
        this.GetComponent<Rigidbody2D>().MovePosition(newPos);
    }

    public void SetPos(Vector2 pos)
    {
        this.transform.position = pos;
    }
}