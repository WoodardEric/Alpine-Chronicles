using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGruntBug : MonoBehaviour, IHitEnemies
{
    public float EnemyHealth = 100.0f;
    public float EnemyDamage = 10.0f;

    [SerializeField]
    private float moveSpeed = 1.0f;

    [SerializeField]
    private float attackTimer = 1.0f;

    // Remember to keep this correct
    private Vector3 playerTrackingOverride = new Vector3(0.0f, 0.15f, 0.0f);

    private PlayerClass player = null;
    private IHitEnemies playerHit = null;
    private bool alert = false;
    private bool waitForEvent = false;
    private bool hitCooldown = true;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerClass.Instance;
        if(player == null)
        {
            Debug.LogError("The ENEMY can't find an active player");
            this.gameObject.SetActive(false);
        }

        playerHit = player.gameObject.GetComponent<IHitEnemies>();

        UnityEngine.Random.InitState(DateTime.Now.Minute + Mathf.FloorToInt(this.transform.position.magnitude * 4)); // ensures that every enemy has a completley randomly generated number for it's initialization
        StartCoroutine(IdleSequence());
    }

    private void Update()
    {
        //alert = GoOnAlert();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        alert = GoOnAlert();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Bug OnStay: " + collision.gameObject);
        if(collision.gameObject.CompareTag("Player"))
        {
            if(hitCooldown) // If true, it means the enemy CAN attack
            {
                playerHit.DamageEnemy(EnemyDamage);
                hitCooldown = false;
                StartCoroutine(AttackCooldown());
            }
        }
    }

    private bool GoOnAlert()
    {
        Vector3 modifiedPlayerPosition = player.transform.position + playerTrackingOverride;
        Vector3 direction = (modifiedPlayerPosition - this.transform.position).normalized;
        //RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction, 10.0f);
        int maximumCollisions = 16;
        RaycastHit2D[] hitResults = new RaycastHit2D[maximumCollisions]; // maximum number of detected collisions
        ContactFilter2D filter2D = new ContactFilter2D();
        int hit = Physics2D.Raycast(this.transform.position, direction, filter2D, hitResults, 100.0f);

        Debug.DrawLine(this.transform.position, modifiedPlayerPosition, Color.red, 1.0f);
        int count = 0;
        if(hit != 0)
        {
            while (hitResults[count].collider != null && (count < maximumCollisions - 1))
            {
                if (hitResults[count].collider.gameObject.tag == "Player")
                {
                    StopCoroutine("IdleAction");
                    waitForEvent = false;
                    this.transform.position += direction * moveSpeed * 0.02f; // ensures that the enemy move speed is consistent across multiple framerates the game may be running at
                    float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    this.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
                    return true;
                }
                if (hitResults[count].collider.gameObject.CompareTag("Enemy"))
                {
                    count++;
                }
                else
                {
                    return false;
                }
            }
            //if (hitResults[count].collider.gameObject.tag == "Player")
            //{
            //    StopCoroutine("IdleAction");
            //    waitForEvent = false;
            //    this.transform.position += direction * moveSpeed * 0.02f; // ensures that the enemy move speed is consistent across multiple framerates the game may be running at
            //    float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //    this.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            //    return true;
            //}
        }
        return false;
    }

    private void IdleStuff()
    {
        waitForEvent = true;
        StartCoroutine(IdleAction(Mathf.FloorToInt(UnityEngine.Random.Range(0.0f, 3.0f)), UnityEngine.Random.Range(1.0f, 3.0f)));
    }

    private IEnumerator IdleSequence()
    {
        float timer = 1.5f;
        float i = 0.0f;
        while(true)
        {
            if(!alert && !waitForEvent)
            {
                if (i > timer)
                {
                    IdleStuff();
                    i = 0.0f;
                }
                i += Time.deltaTime;
            }

            yield return null;
        }

        yield break;
    }

    private IEnumerator IdleAction(int idleType, float idleLength)
    {
        float timer = (idleType == 0) ? idleLength/3.0f : idleLength;

        Vector3 originalPos = this.transform.position;
        Vector3 originalDir = this.transform.right;
        Vector3 orginialRot = this.transform.eulerAngles;

        int spinDirection = (((Mathf.FloorToInt(idleLength * 11.5f) % 2) * 2) - 1);

        for(float i = 0.0f; i < timer; i += Time.deltaTime) // effectivley creates a timer where we can specify certain tasks to be executed at any given time.
        {
            float smooth = (3 * Mathf.Pow((i / timer), 2)) - (2 * Mathf.Pow((i / timer), 3));
            switch (idleType)
            {
                case 0:
                    this.transform.eulerAngles = new Vector3(orginialRot.x, orginialRot.y, Mathf.Lerp(orginialRot.z, orginialRot.z + (spinDirection * idleLength * 25.0f), smooth)); // rotates in a random direction
                    break;
                case 1:
                    //this.transform.position = Vector3.Lerp(originalPos, originalPos + (originalDir * idleLength * 2.5f), smooth); // moves forward a random ammount of units
                    this.transform.position += this.transform.right * Time.deltaTime * Mathf.Sin((i/timer) * 3.1415f) * 2.5f;
                    break;
                default:
                    //foo
                    break;
            }

            yield return null;
        }

        waitForEvent = false;
        yield break;
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSecondsRealtime(attackTimer);
        hitCooldown = true;
        yield break;
    }

    public void DamageEnemy(float damage)
    {
        EnemyHealth -= damage;

        if(EnemyHealth <= 0.0f)
        {
            EnemyDeath();
        }
    }

    /// <summary>
    /// Calling this kills the enemy this script is attached to
    /// </summary>
    private void EnemyDeath()
    {
        Destroy(this.gameObject);
    }
}