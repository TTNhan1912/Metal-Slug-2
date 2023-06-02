using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPisTol : MonoBehaviour
{
    private bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // di chuyển đạn
        transform.Translate((isRight ? Vector3.right : Vector3.left) * Time.deltaTime * 20f);
    }

    public void setIsRight(bool isRight)
    {
        this.isRight = isRight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // bắn trúng enemis
        if (collision.gameObject.CompareTag("linhbo"))
        {
            Destroy(gameObject);

        }
    }
}
