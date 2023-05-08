using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class Player : MonoBehaviour
{
    public Animator ani;
    public bool isRight = true;
    public bool nen_dat;
    // public Animator animator;
    public float Run;
    public bool isJump;
    public Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {

        ani = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        Run = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;

            ani.SetBool("IsRunning", true);
            ani.Play("running");


            transform.Translate(Time.deltaTime * 5, 0, 0);


            transform.localScale = new Vector3(1F, 1F, 1F);
        }
        else
        {
            ani.SetBool("IsRunning", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = false;

            ani.SetBool("IsRunning", true);
            ani.Play("running");


            transform.Translate(-Time.deltaTime * 5, 0, 0);
            transform.localScale = new Vector3(-1F, 1F, 1F);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if (nen)
            //{

            rigidbody2d.AddForce(new Vector2(0, 400));
                //nen = false;
            //}

        }

    }
}
