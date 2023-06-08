using UnityEngine;

public class LuuDan : MonoBehaviour
{
    public float speedUp = 5f; // Lực đẩy ném lên
    public float speedWay = -5f; // Lực đẩy ném qua
    //public Transform groundCheck; // Transform của một GameObject empty để kiểm tra nền

    //private bool isThrown = false;
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        ThrowGrenade();
    }

    private void Update()
    {
  
    }

    private void ThrowGrenade()
    {
        // Áp dụng lực đẩy ném lên
        Vector2 force = new Vector2(speedWay, speedUp);
        rb.AddForce(force, ForceMode2D.Impulse);

        // Bắt đầu animation
        anim.Play("luudanNem");
        //anim.SetBool("luudanNem", true);

        //isThrown = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // lựu đạn chạm đất
        if (collision.gameObject.CompareTag("nen_dat"))
        {
            // animation nổ
            anim.SetBool("isNo", true);
            anim.Play("luudanNo");
            //dừng di chuyển
            Vector2 force = new Vector2(0, 0);
            rb.AddForce(force, ForceMode2D.Impulse);

            //thu nhỏ do hình nổ bự hơn lựu đạn
            Vector2 scale = transform.localScale;
            scale.x = 0.5f;
            scale.y = 0.5f;
            // up lại scale
            transform.localScale = scale;

            // mất hình
            Destroy(gameObject,0.25f);
        }
        // lựu đạn chạm player
        if (collision.gameObject.CompareTag("Player"))
        {
            // animation nổ
            anim.SetBool("isNo", true);
            anim.Play("luudanNo");
            //dừng di chuyển
            Vector2 force = new Vector2(0, 0);
            rb.AddForce(force, ForceMode2D.Impulse);

            //thu nhỏ do hình nổ bự hơn lựu đạn
            Vector2 scale = transform.localScale;
            scale.x = 0.5f;
            scale.y = 0.5f;
            // up lại scale
            transform.localScale = scale;

            // mất hình
            Destroy(gameObject, 0.25f);

        }
    }
}