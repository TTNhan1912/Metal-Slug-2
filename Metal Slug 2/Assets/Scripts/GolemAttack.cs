using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttack : MonoBehaviour
{
    public static int live;
    // Start is called before the first frame update
    void Start()
    {
       // isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Golem.isAttack)
        {
            live = 1;
            Debug.Log("live" + live);
        }
    }
}
