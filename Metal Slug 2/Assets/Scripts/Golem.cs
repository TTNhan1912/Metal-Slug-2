using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Golem : MonoBehaviour
{
    
    public float moveSpeed;
    public float nextWPDistance;
    public SpriteRenderer characterSR;
    private Animator animator;

    public Seeker seeker;
    Path path;
    Coroutine moveCoroutine;
    bool reachDestination = false;
    public bool updateContinuesPath;

    public static bool isAttack = false;
    public bool attackBlock;

    public GameObject vitriban;
    Vector3 viTriBan;
    public GameObject rocket;
    public float rocketSpeed;
    public float timeRocket;
    private float rocketCooldown;
    private float time;

    public float Life;
    public static bool isLife;


    private void Start()
    {
        InvokeRepeating("CalculatePath", 0f, 0.5f);
        reachDestination = true;
        animator = GetComponent<Animator>();
        isLife = true;
        
        time = 10;
    }

    private void Update()
    { 
        if(IsBoss.isBoss)
        {
            if (isLife == false) return;
            moveSpeed = 3;
            time -= Time.deltaTime;
            if (time < 0)
            {
                viTriBan = vitriban.transform.position;
                rocketCooldown -= Time.deltaTime;
                if (rocketCooldown < 0)
                {

                    rocketCooldown = timeRocket;
                    StartCoroutine(delay());


                }
            }
        }
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(1f);
        isAttack = false;
        attackBlock = false;
    }

    IEnumerator delay()
    {
        animator.SetTrigger("spit");
        yield return new WaitForSeconds(0.7f);
        var bulletmp = Instantiate(rocket, viTriBan, Quaternion.identity);
        Rigidbody2D rb = bulletmp.GetComponent<Rigidbody2D>();
        Vector3 playerPos = FindObjectOfType<Player>().transform.position;
        Vector3 direction = playerPos - viTriBan;
        rb.AddForce(direction.normalized * rocketSpeed, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isLife == false) return;
            if (attackBlock) return;
            int random = Random.Range(0, 2);
            Debug.Log(random);
            if (random == 0)
            {
                animator.SetTrigger("attack2");
                isAttack = true;

            }
            else
            {
                animator.SetTrigger("attack1");
                isAttack = true;

            }
            attackBlock = true;
            StartCoroutine(attack());

        }

        if (collision.gameObject.CompareTag("BulletPistol"))
        {
            if (isLife == false) return;
            Destroy(collision.gameObject);
            Life--;
            if (Life == 0)
            {
                isLife = false;
                moveSpeed = 0;
                animator.SetBool("death", true);
            }
        }

    }
    void CalculatePath()
    {
        Vector2 target = FindTarget();
        if (seeker.IsDone() && (reachDestination || updateContinuesPath))
            seeker.StartPath(transform.position, target, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (p.error) return;
        path = p;
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;
        reachDestination = false;
        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;
            animator.SetFloat("run", direction.sqrMagnitude);

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
            {
                currentWP++;
            }

            if (force.x != 0)
            {
                if (force.x < 0)
                {
                    characterSR.transform.localScale = new Vector3(1f, 1f, 0);
                }
                else
                {
                    characterSR.transform.localScale = new Vector3(-1f, 1f, 0);
                }
            }

            yield return null;

        }
        reachDestination = true;
    }

    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<Player>().transform.position;
       
        return playerPos;
       
    }

}
