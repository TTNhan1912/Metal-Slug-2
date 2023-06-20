using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((isRight ? Vector3.right : Vector3.left) * Time.deltaTime * 15f);
    }
    public void setIsRight(bool isRight)
    {
        this.isRight = isRight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("luudan"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("nen_dat"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("linhbo"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("boss"))
        {
            Destroy(gameObject);
        }

    }

}
