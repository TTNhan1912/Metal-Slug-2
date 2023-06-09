using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleItems : MonoBehaviour
{

    private Collider2D collider;
    public static int isCoin;
    private void Start()
    {
        collider = GetComponent<Collider2D>();

        string tag = gameObject.tag;

        // trái cây héo, mất sau 4s nếu ko được ăn
        if(tag == "item_traicay")
        {
            Destroy(gameObject,4);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // nhân vật ăn item
        if (collision.gameObject.CompareTag("Player"))
        {
            if (tag == "item_traicay")
            {
                // Xử lý logic cho đối tượng có tag "item_traicay"
                //mất item
                Destroy(gameObject);
                Debug.Log("trai cay");
            }
            else if (tag == "item_boom")
            {
                // Xử lý logic cho đối tượng có tag "item_boom"
                //mất item
                Destroy(gameObject);
                Debug.Log("boom");
            }
            else if (tag == "item_hp")
            {
                // Xử lý logic cho đối tượng có tag "item_hp"
                //mất item
                Destroy(gameObject);
                Debug.Log("hp");
            }
            else if (tag == "item_sting")
            {
                // Xử lý logic cho đối tượng có tag "item_sting"
                //mất item
                Destroy(gameObject);
                Debug.Log("sting");
            }
            else if (tag == "item_vang")
            {
                // Xử lý logic cho đối tượng có tag "item_vang"
                isCoin = 1;
                //mất item
                Destroy(gameObject);
                Debug.Log("vang");
            }
            else
            {
                isCoin = 0;
                // Xử lý logic mặc định cho các đối tượng khác
                Debug.Log("Default logic");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nen_dat"))
        {
            // Tắt thuộc tính isTrigger khi chạm đất
            //if (tag == "item_traicay" || tag == "item_boom" || tag == "item_sting"
            //    || tag == "item_hp" || tag == "item_vang")
            //{
                collider.isTrigger = false;
            //}
        }
    }
}
