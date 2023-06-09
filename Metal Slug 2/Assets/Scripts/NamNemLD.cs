using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NamNemLD : MonoBehaviour
{
    private Animator ani;
    //
    private bool isDie;
    //private bool isAlive;
    private bool isFlipped = false; // Biến xác định trạng thái đảo hướng


    public GameObject luudan;
    //public float speed;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        //isChem = false;
        isDie = false;
        StartCoroutine(ThrowGrenadeRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        // chết
        if (isDie)
        {
            Destroy(gameObject, 1.3f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // trúng đạn
        if (collision.gameObject.CompareTag("BulletPistol"))
        {
            FlipCharacter();
            ani.SetBool("isDie", true);

            ani.Play("linhchoildDie");

           // ani.Play("linhnamldDie");

            isDie = true;

        }
    }

    private void FlipCharacter()
    {
        // Đảo ngược hướng scale.x của nhân vật
        Vector3 scale = transform.localScale;
            scale.x *= 1f;
            scale.y *= 1f;
        transform.localScale = scale;

        isFlipped = !isFlipped;
    }
    private IEnumerator ThrowGrenadeRoutine()
    {
        while (true)
        {
            // Chờ một khoảng thời gian
            yield return new WaitForSeconds(2.4f);

            // Tạo lựu đạn tại vị trí của nhân vật
            Instantiate(luudan, transform.position, Quaternion.identity);
        }
    }
}
