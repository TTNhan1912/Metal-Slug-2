using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Linhbo : MonoBehaviour
{
    public float start, end;
    private bool isRight;

    private Animator ani;
    //
    private bool isDie;
    private bool isChem;
    private bool isFlipped = false; // Biến xác định trạng thái đảo hướng


    public GameObject Player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        isChem = false;
        isDie = false;
    }

    // Update is called once per frame
    void Update()
    {
        var positionE = transform.position.x;

        // dí player
        var positionPlay = Player.transform.position.x;
        if (positionPlay > start && positionPlay < end)
        {
            // tự động quay mặt
            if (positionPlay < positionE) isRight = false;
            if (positionPlay > positionE) isRight = true;

        }

        if (positionE < start)
        {
            isRight = true;
        }
        if (positionE > end)
        {
            isRight = false;
        }

        Vector2 scale = transform.localScale;
        if (isRight)
        {
            scale.x = -5f;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            scale.x = 5f;
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // up lại scale
        transform.localScale = scale;

        //
        
        if (isChem)
        {
            ani.SetBool("isChem", false);
            ani.SetBool("isRun", true);
            ani.Play("linhboRun");
            isChem = false;
        }

        // chết
        if (isDie)
        {
            speed = 0f;
            Destroy(gameObject,1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isChem)
        {
            FlipCharacter();
            ani.SetBool("isChem", true);
            ani.Play("linhboChem");
            isChem = true;
            
        }
        // trúng đạn
        if (collision.gameObject.CompareTag("BulletPistol"))
        {
            ani.SetBool("isDie", true);
            ani.Play("linhboDie");
            isDie = true;

        }
    }

    private void FlipCharacter()
    {
        // Đảo ngược hướng scale.x của nhân vật
        Vector3 scale = transform.localScale;
        if (!isRight)
        {
            scale.x *= -5f;
        }
        else
        {
            scale.x *= 5f;
        }
        transform.localScale = scale;

        isFlipped = !isFlipped;
    }
}
