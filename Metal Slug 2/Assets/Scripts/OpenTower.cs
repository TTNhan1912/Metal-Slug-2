using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTower : MonoBehaviour
{
    private Animator animator;

    public GameObject vitriban;
    Vector3 viTriBan;
    public GameObject bullet;
    public float bulletSpeed;
    public float timeBullet;
    private float fireCooldown;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        viTriBan = vitriban.transform.position;
        time = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Tower.isPlay == true)
        {
            animator.SetTrigger("open");

            time -= Time.deltaTime;
            if(time < 0)
            {
                fireCooldown -= Time.deltaTime;
                if (fireCooldown < 0)
                {
                    fireCooldown = timeBullet;
                    var bulletmp = Instantiate(bullet, viTriBan, Quaternion.identity);
                    Rigidbody2D rb = bulletmp.GetComponent<Rigidbody2D>();
                    Vector3 playerPos = FindObjectOfType<Player>().transform.position;
                    Vector3 direction = playerPos - viTriBan;
                    Debug.Log(">>>>>>"+ playerPos);
                    rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
                    Destroy(bulletmp, 3f);
                }
            }
           
        }

        
    }
}
