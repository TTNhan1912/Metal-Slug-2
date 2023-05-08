using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arabian : MonoBehaviour
{
    public float start, end;
    private bool isRight;

    private Animator ani;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
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
            scale.x = -4f;
            transform.Translate(Vector3.right * 2f * Time.deltaTime);
        }
        else
        {
            scale.x = 4f;
            transform.Translate(Vector3.left * 2f * Time.deltaTime);
        }

        // up lại scale
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ani.SetBool("attack", true);
            ani.Play("arabianAttack");
        }
    }
}
