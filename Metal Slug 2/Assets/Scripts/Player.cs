using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.Arm;

public class Player : MonoBehaviour
{
    int count = 0;
    private Animator ani;
    public bool isRight = true;
    public bool nen_dat;

    // public Animator animator;
    public float Run;
    public bool isJump;
    private Rigidbody2D rigidbody2d;

    // tăng boom
    private int boom = 10;
    public Text textBoom;

    // mạng
    private int life;
    public bool isAlive;
    public GameObject Alive1;
    public GameObject Alive4;
    public GameObject Alive3;
    public GameObject Alive5;
    public GameObject Alive2;
    

    // Start is called before the first frame update
    void Start()
    {

        ani = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        Run = 0;
        nen_dat = true;

        isAlive = false;
        life = 5;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
            if(nen_dat == true)
            {
                ani.SetBool("IsRunning", true);
                ani.Play("running");
            }
            else
            {
                ani.SetBool("IsJump", true);
                ani.Play("jump");
            }

            transform.Translate(Time.deltaTime * 5, 0, 0);
            transform.localScale = new Vector3(0.8F, 0.8F, 0.8F);
        }
        else
        {
            ani.SetBool("IsRunning", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = false;

            if (nen_dat == true)
            {
                ani.SetBool("IsRunning", true);
                ani.Play("running");
            }
            else
            {
                ani.SetBool("IsJump", true);
                ani.Play("jump");
            }


            transform.Translate(-Time.deltaTime * 5, 0, 0);
            transform.localScale = new Vector3(-0.8F, 0.8F, 0.8F);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (nen_dat)
            {
                rigidbody2d.AddForce(new Vector2(0, 420));
                nen_dat = false;
                ani.SetBool("IsJump", true);
                ani.Play("jump");
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (count == 0)
            {
                var x = transform.position.x + (isRight ? 1.5f : -1.5f);
                var y = transform.position.y + (isRight ? 0.5f : 0.5f);
                var z = transform.position.z;

                // chuyển isright ben bullet qua bên đây
                GameObject gameObject = (GameObject)Instantiate(Resources.Load("Prefabs/BulletPistol"),
                new Vector3(x, y, z),
                Quaternion.identity);
                gameObject.GetComponent<BulletPisTol>().setIsRight(isRight);

                ani.SetBool("IsShoot", true);
                ani.Play("shoot");
                count = 1; 
            }
            if(count == 1)
            {
                ani.SetBool("IsShoot", false);
                ani.Play("shoot");
                count = 0;
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && boom > 0)
        {
            if (count == 0)
            {
                boom--;
                textBoom.text = boom + "";
                var x = transform.position.x + (isRight ? 1.5f : -1.5f);
                var y = transform.position.y + (isRight ? 1f : 1f);
                var z = transform.position.z;

                // chuyển isright ben bullet qua bên đây
                GameObject gameObject = (GameObject)Instantiate(Resources.Load("Prefabs/Boom"),
                new Vector3(x, y, z),
                Quaternion.identity);
                gameObject.GetComponent<Boom>().setIsRight(isRight);

                ani.SetBool("IsThrowBoom", true);
                ani.Play("throwBoom");
                count = 1; 
            }
            if(count == 1)
            {
                ani.SetBool("IsThrowBoom", false);
                ani.Play("throwBoom");
                count = 0;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("nen_dat"))
        {
            nen_dat = true;
            ani.SetBool("IsJump", false);
        }
        else if (collision.gameObject.CompareTag("Arabian"))
        {
            ani.SetBool("IsDeadByDao", true);
            ani.Play("DeadByDao");
            lifeCheck();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boom"))
        {
            boom++;
            textBoom.text = boom + "";
        }
    }

    private void lifeCheck()
    {
        if(life == 5)
        {
            life--;
            var x = transform.position.x;
            var y = transform.position.y + 5f;
            transform.localPosition = new Vector2(x, y);
            Alive5.SetActive(false);
        }
        else if (life == 4)
        {
            life--;
            var x = transform.position.x;
            var y = transform.position.y + 5f;
            transform.localPosition = new Vector2(x, y);
            Alive4.SetActive(false);
        }
        else if (life == 3)
        {
            life--;
            var x = transform.position.x;
            var y = transform.position.y + 5f;
            transform.localPosition = new Vector2(x, y);
            Alive3.SetActive(false);
        }
        else if (life == 2)
        {
            life--;
            var x = transform.position.x;
            var y = transform.position.y + 5f;
            transform.localPosition = new Vector2(x, y);
            Alive2.SetActive(false);
        }
        else if (life == 1)
        {
            life--;
            var x = transform.position.x;
            var y = transform.position.y + 5f;
            transform.localPosition = new Vector2(x, y);
            Alive1.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("Man_1");
        }
    }
}
